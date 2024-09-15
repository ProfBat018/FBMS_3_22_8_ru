using System.Net;
using Newtonsoft.Json;
using UserService.Exceptions;

namespace AuthApiService.Middlewares;


public class GlobalExceptionsMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;

        AuthErrorTypes types = (exception as MyAuthException).AuthErrorType;
        
        switch (types)
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
        
        var result = JsonConvert.SerializeObject(new { error = exception.Message });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        return context.Response.WriteAsync(result);
    }
}