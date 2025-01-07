using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using CommunicationService.Data.Contexts;
using CommunicationService.Protos.GrpcUserService;
using CommunicationService.Services.Implenetations;
using CommunicationService.Services.Interfaces;
using Grpc.Net.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddKeyPerFile("/secrets", optional: true);


builder.Services.AddControllers();

builder.Services.AddGrpcClient<UserService.UserServiceClient>(options =>
{
    options.Address = new Uri(builder.Configuration["gRPC:UserService"]); 
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<CommunicationContext>(ops => ops.UseSqlServer(
    builder.Configuration["CommunicationDb"]));


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
        ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
        ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
        IssuerSigningKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value))
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

builder.Services.AddScoped<ISubscribeService, SubscribeService>();

builder.Services.AddScoped<INotificationService, NotificationService>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AppUser", policy => policy.RequireClaim(ClaimTypes.Role, "AppUser"));
    options.AddPolicy("AppAdmin", policy => policy.RequireClaim(ClaimTypes.Role, "AppAdmin"));
    options.AddPolicy("AppUserOrAdmin", policy => policy.RequireClaim(ClaimTypes.Role, "AppUser", "AppAdmin"));
});



var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseCookiePolicy();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
