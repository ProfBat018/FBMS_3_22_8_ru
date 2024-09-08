using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using UserService.Interfaces;

namespace UserService.Middlewares;

public class JwtSessionMiddleware : IMiddleware
{
    private readonly IBlackListService blackListService;

    public JwtSessionMiddleware(IBlackListService blackListService)
    {
        this.blackListService = blackListService;
    }
   
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        string? token = context.Request.Headers["Authorization"];

        if (string.IsNullOrWhiteSpace(token))
        {
            await next(context);
            return;
        }
        
        token = token.Replace("Bearer ", "");
        
        if (blackListService.IsTokenBlackListed(token))
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Unauthorized");
            return;
        }

        await next(context);
    }
}
