using System.Net;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using WebServer.Controllers;
using WebServer.Middlewares.Delegates;
using WebServer.Middlewares.Interfaces;
using WebServer.Services.Classes.MainJobs;

namespace WebServer.Middlewares.Classes;

public class MvcMiddleware : IMiddleware
{
    public HttpHandler Next { get; set; }
        
    public void Handle(HttpListenerContext context)
    {
        // context.RawUrl = "/Home/Index"
        
        var parts = context.Request.RawUrl.Split('/', StringSplitOptions.RemoveEmptyEntries);
        var controllerName = $"WebServer.Controllers.{parts[0]}Controller";

        if (parts.Length == 1)
        {
            return;
        }
        var methodName = parts[1].Split('?')[0];

        Assembly currentAssembly = Assembly.GetExecutingAssembly();
        
        // Беру класс с нужным мне названием из поисковой строки
        var controllerType = currentAssembly.GetType(controllerName);

        if (controllerType != null)
        {
            var controllerObj = WebHost.Container.GetRequiredService(controllerType) as Controller;
            
            controllerObj.Context = context;
            
            var controllerMethod = controllerType.GetMethod(methodName);

            if (controllerMethod != null)
            {
                // var parameters = controllerMethod.GetParameters();
                //
                // object[] paramValues = new object[parameters.Length];
                //
                // int i = 0;
                // foreach (var item in parameters)
                // {
                //     paramValues[i++] = Convert.ChangeType(context.Request.QueryString[item.Name], item.ParameterType);
                // }
                controllerMethod.Invoke(controllerObj, null);
            }
        }
        Next?.Invoke(context);
    }
}