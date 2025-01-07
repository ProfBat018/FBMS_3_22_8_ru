using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Movies;
using Movies.Contexts;
using Movies.Middlewares;
using Movies.Services.Classes;
using Movies.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddKeyPerFile("/secrets", optional: true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddDbContext<MovieContext>(ops => ops.UseSqlServer(
    builder.Configuration["MoviesDb"]));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        RoleClaimType = ClaimTypes.Role,
        ValidateActor = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        RequireExpirationTime = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };

    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.HttpContext.Request.Cookies["accessToken"];
            if (!string.IsNullOrEmpty(accessToken))
            {
                context.Token = accessToken;
            }

            return Task.CompletedTask;
        }
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AppUser", policy => policy.RequireClaim(ClaimTypes.Role, "AppUser"));
    options.AddPolicy("AppAdmin", policy => policy.RequireClaim(ClaimTypes.Role, "AppAdmin"));
    options.AddPolicy("AppUserOrAdmin", policy => policy.RequireClaim(ClaimTypes.Role, "AppUser", "AppAdmin"));
});

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddSingleton<GlobalExceptionMiddleware>();
builder.Services.AddScoped<IMovieService, MovieService>();  

var app = builder.Build();
app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCookiePolicy();

app.UseAuthentication();
app.UseAuthorization();


app.UseHttpsRedirection();
app.MapControllers();

app.Run();

