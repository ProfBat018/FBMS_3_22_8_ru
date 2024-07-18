using System.Net;
using WebServer.Middlewares.Interfaces;

namespace WebServer.Middlewares.Classes
{
    internal class LoggerMiddleware : IMiddleware
    {
        public HttpHandler? Next { get; set; }

        public void Handle(HttpListenerContext context)
        {
            Console.WriteLine(context.Request.UserHostAddress);

            Next?.Invoke(context);
        }
    }
}
