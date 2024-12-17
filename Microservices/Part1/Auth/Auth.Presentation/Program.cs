
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Auth.Application.DTO;
using Auth.Application.Implementations;
using Auth.Application.Validators;
using Auth.Core.Interfaces;
using Auth.Infrastructure.Contexts;
using Auth.Presentation.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("Client")
    .ConfigurePrimaryHttpMessageHandler(() =>
    {
        return new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        };
    });


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});


builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.Strict;
    options.HttpOnly = HttpOnlyPolicy.Always;
    options.Secure = CookieSecurePolicy.None;
});

builder.Services.AddHttpClient("MyClient");

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
        },
        OnAuthenticationFailed = async context =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                var httpContext = context.HttpContext;
                var accessToken = 
                    httpContext.Request.Cookies["accessToken"];

                var refreshToken =
                    httpContext.Request.Cookies["refreshToken"];

                if (!string.IsNullOrEmpty(refreshToken))
                {
                    var refreshEndpoint =
                        $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/api/v1/Auth/Refresh";
                    var client = httpContext.RequestServices.GetRequiredService<IHttpClientFactory>().CreateClient();
                    
                    var response = await client.PostAsJsonAsync(refreshEndpoint, new TokenDTO(accessToken, refreshToken));
                    
                    if (response.IsSuccessStatusCode)
                    {
                        var newTokens = await response.Content.ReadFromJsonAsync<Refresh_DTO>();
                        if (newTokens != null)
                        {
                            httpContext.Response.Cookies.Append("accessToken", newTokens.accessToken, new CookieOptions { HttpOnly = true });
                            httpContext.Response.Cookies.Append("refreshToken", newTokens.refreshToken, new CookieOptions { HttpOnly = true });
                            
                            httpContext.Request.Headers["Authorization"] = $"Bearer {newTokens.accessToken}";

                            var newToken = new JwtSecurityToken(newTokens.accessToken);
                            var principal = new ClaimsPrincipal(new ClaimsIdentity(newToken.Claims, "jwt"));

                            context.Principal = principal;
                            context.Success();  
                        }
                    }
                }
            }
        }
    };
});

builder.Services.AddAuthorization();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApiVersioning(options => { options.ReportApiVersions = true; }
).AddApiExplorer(
    options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AuthContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultMacAuth"));
});



builder.Services.AddScoped<LoginUserValidator>();
builder.Services.AddScoped<RegisterUserValidator>();

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IBlackListService, BlackListService>();
builder.Services.AddScoped<JwtSessionMiddleware>();
builder.Services.AddScoped<GlobalExceptionsMiddleware>();
builder.Services.AddSingleton<IEmailSender, EmailSender>();

var app = builder.Build();


app.UseCors();

app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCookiePolicy();

app.UseHttpsRedirection();
app.UseMiddleware<GlobalExceptionsMiddleware>();
app.UseMiddleware<JwtSessionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();