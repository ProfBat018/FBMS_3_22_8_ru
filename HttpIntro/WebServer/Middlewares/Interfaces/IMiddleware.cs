using System.Net;
using WebServer.Middlewares.Delegates;

namespace WebServer.Middlewares.Interfaces;

public interface IMiddleware
{
    public void Handle(HttpListenerContext context);

    public HttpHandler? Next { get; set; }
}