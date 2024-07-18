using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace WebServer.Middlewares.Interfaces
{
    public interface IMiddleware
    {
        // Handle - это действие, которые совершает мой Middleware
        public void Handle(HttpListenerContext context); 
        
        // Next - делегат, который делегирует принимаемый контекст на следующий Middleware.Handle(); 
        public HttpHandler Next { get; set; }
    }
}
