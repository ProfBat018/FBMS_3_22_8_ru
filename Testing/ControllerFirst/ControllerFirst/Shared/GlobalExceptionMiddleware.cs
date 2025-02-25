using System.Net;
using ControllerFirst.DTO.Responses;
using FluentValidation;
using Newtonsoft.Json;

namespace ControllerFirst.Shared;

public class GlobalExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;

            var errors = ex.Errors.Select(x => x.ErrorMessage);
            
            var errorRes = Result<IEnumerable<string>>.Error(errors, "Validation error");
            
            context.Response.ContentType = "application/json";
            
            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorRes));
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }
    
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var errorRes = Result<string>.Error(exception.Message, "Internal server error");
        
        var result = JsonConvert.SerializeObject(errorRes);
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsync(result);
    }
}