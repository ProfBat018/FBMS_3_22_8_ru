using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.IdentityModel.Tokens.Jwt;
using ApiFirst.Services.Interfaces;

namespace ApiFirst.Middlewares;

public class JwtSessionMiddleware : IMiddleware
{
    private readonly IBlackListService blackListService;

    public JwtSessionMiddleware(IBlackListService blackListService)
    {
        this.blackListService = blackListService;
    }
   
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        string token = context.Request.Headers["Authorization"];

        token = token?.Replace("Bearer ", "");

        if (string.IsNullOrWhiteSpace(token))
        {
            await next(context);
            return;
        }

        if (blackListService.IsTokenBlackListed(token))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized");
            return;
        }

        await next(context);
    }
}
