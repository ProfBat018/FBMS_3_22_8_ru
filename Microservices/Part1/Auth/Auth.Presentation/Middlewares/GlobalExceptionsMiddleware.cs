using System.Net;
using Auth.Shared.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using UserService.Exceptions;

namespace Auth.Presentation.Middlewares;


public class GlobalExceptionsMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }
    
    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var result = JsonConvert.SerializeObject(new { error = exception.Message });
        context.Response.ContentType = "application/json";

        return context.Response.WriteAsync(result);
    }
}