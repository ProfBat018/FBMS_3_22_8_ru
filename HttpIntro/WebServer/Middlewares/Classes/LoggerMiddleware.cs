using System.Net;
using WebServer.Middlewares.Delegates;
using WebServer.Middlewares.Interfaces;

namespace WebServer.Middlewares.Classes;

public class LoggerMiddleware : IMiddleware
{
    public void Handle(HttpListenerContext context)
    {
        using FileStream fs = new("logs.json", FileMode.Append);
        using StreamWriter sw = new(fs);
        
        sw.WriteLine($"{context.Request.RawUrl}\t{context.Request.UserHostAddress}");
        
        Next?.Invoke(context);
    }
    public HttpHandler Next { get; set; }
}