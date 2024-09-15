using System.Net;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using UserService.Exceptions;

namespace UserService.Middlewares;


public class GlobalExceptionsMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (MyAuthException ex)
        {
            await HandleExceptionAsync(context, ex);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }
    
    private Task HandleExceptionAsync(HttpContext context, MyAuthException exception)
    {
        var code = HttpStatusCode.InternalServerError;
        
        switch (exception.AuthErrorType)
        {
            case AuthErrorTypes.InvalidCredentials:
                code = HttpStatusCode.Unauthorized;
                break;
            case AuthErrorTypes.InvalidRequest:
                code = HttpStatusCode.BadRequest;
                break;
            case AuthErrorTypes.InvalidToken:
                code = (HttpStatusCode)498;
                break;
            case AuthErrorTypes.PasswordMismatch:
                code = HttpStatusCode.Unauthorized;
                break;
            case AuthErrorTypes.EmailAlreadyConfirmed:
                code = HttpStatusCode.NoContent;
                break;
            case AuthErrorTypes.EmailNotConfirmed:
                code = HttpStatusCode.Unauthorized;
                break;
        }
        
        var result = JsonConvert.SerializeObject(new { error = exception.Message});
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        return context.Response.WriteAsync(result);
    }
    
    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;
        
        var result = JsonConvert.SerializeObject(new { error = exception.Message });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        return context.Response.WriteAsync(result);
    }
}