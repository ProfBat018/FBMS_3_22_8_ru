using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProductData.Contexts;
using ProductRepo.Interfaces;
using ProductRepository.Classes;
using ProductService.İnterfaces;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.WithOrigins("http://localhost:3001", "http://localhost:3000", "http://localhost:5040")
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            });
        });

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                RequireExpirationTime = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidAudience = _configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
            };

            // Опция для извлечения JWT из cookie
            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    // Проверяем, если заголовок Authorization не установлен
                    if (context.Request.Cookies.TryGetValue("accessToken", out var token))
                    {
                        context.Token = token; // Устанавливаем токен из cookie
                    }
                    return Task.CompletedTask;
                }
            };
        });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminPolicy", policy =>
                policy.RequireRole("AppAdmin"));

            options.AddPolicy("UserPolicy", policy =>
                policy.RequireRole("AppUser", "AppAdmin"));
        });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        services.AddDbContext<ProductContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("StepEcommerce16")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IProductService, ProductService.Classes.ProductService>();

        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
