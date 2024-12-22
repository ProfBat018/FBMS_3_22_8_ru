using System.Net;
using Movies.Models;
using Newtonsoft.Json;

namespace Movies.Middlewares;

public class GlobalExceptionMiddleware : IMiddleware
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
        var code = HttpStatusCode.InternalServerError;

        var result = ResponseModel<object>.ErrorResponse(exception.Message, code.ToString());
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 200;

        return context.Response.WriteAsync(JsonConvert.SerializeObject(result));
    }
}