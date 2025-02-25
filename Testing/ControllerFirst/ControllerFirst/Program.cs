using System.Reflection;
using System.Text;
using ControllerFirst.Contexts;
using ControllerFirst.Data.Mapping;
using ControllerFirst.Data.Validators;
using ControllerFirst.DTO.Requests;
using ControllerFirst.Services.Classes;
using ControllerFirst.Services.Interfaces;
using ControllerFirst.Shared;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();



// builder.Services.AddValidatorsFromAssemblyContaining<RegisterValidator>();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var allValidators = Assembly.GetExecutingAssembly().GetTypes()
    .Where(t => t.BaseType != null && t.BaseType.IsGenericType &&
                t.BaseType.GetGenericTypeDefinition() == typeof(AbstractValidator<>));

foreach (var validator in allValidators)
{
    builder.Services.AddValidatorsFromAssemblyContaining(validator);
}

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.Strict;
    options.HttpOnly = HttpOnlyPolicy.Always;
    options.Secure = CookieSecurePolicy.None;
});


builder.Services.AddCors(policy =>
{
    policy.AddPolicy("Default", builder =>
    {
        builder
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddTransient<AuthContext>();

// JWT configuration

// Ставлю по умолчанию валидацию токена по JWT
builder.Services.AddAuthentication(options => {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
        };

        options.Events = new JwtBearerEvents()
        {
            OnMessageReceived = context =>
            {
                var accessToken = context.HttpContext.Request.Cookies["accessToken"];
                if (!string.IsNullOrEmpty(accessToken))
                {
                    context.Token = accessToken;
                }

                return Task.CompletedTask;
            },
            OnForbidden = async context =>
            {
                var authService = context.HttpContext.RequestServices.GetRequiredService<IAuthService>();
                var tokenService = context.HttpContext.RequestServices.GetRequiredService<ITokenService>();
                
                
                var accessToken = context.Request.Cookies["accessToken"];
                var refreshToken = context.Request.Cookies["refreshToken"];
                
                var username = await tokenService.GetNameFromToken(accessToken);

                var result = await authService.RefreshTokenAsync(new RefreshTokenRequest(username, refreshToken));

                context.Response.Cookies.Append("accessToken", result.accessToken);
                context.Response.Cookies.Append("refreshToken", result.refreshToken);

                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("AppAdmin"));
    options.AddPolicy("UserPolicy", policy => policy.RequireRole("AppUser", "AppAdmin"));
    
});


builder.Services.AddAutoMapper(ops => { ops.AddProfile<UserProfile>(); });

builder.Services.AddDbContext<AuthContext>(ops =>
{
    ops.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddScoped<IAuthService, AuthService>(); 
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<GlobalExceptionMiddleware>();

var app = builder.Build();

app.UseCors("Default");


app.UseAuthentication();
app.UseAuthorization(); // Подключаю авторизацию

app.UseHttpsRedirection();


app.MapControllers();
app.MapOpenApi();
app.MapScalarApiReference();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.Run();