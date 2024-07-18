using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Middlewares.Interfaces;

namespace WebServer.Middlewares.Classes
{
    public class MiddlewareBuilder
    {
        // Type - class, который хранит информацию о типе 
        // По сути в моем Stack будет храниться информация о типах:
        // WebServer.Middlewares.Classes.LoggerMiddleware
        // WebServer.Middlewares.Classes.StaticFilesMiddleware
        // WebServer.Middlewares.Classes.MVCMiddleware
        
        private Stack<Type> middlewares = new(); // MVCMiddleware LoggerMiddleware StaticFilesMiddleware 
        
        public void Use<T>() where T : IMiddleware
        {
            middlewares.Push(typeof(T));
        }

        public HttpHandler Build()
        {
            // context.Response.Close() - последний middleware, который закрывает соединение
            HttpHandler handler = context => context.Response.Close();

            while (middlewares.Count != 0)
            {
                Type type = middlewares.Pop();

                var middleware = Activator.CreateInstance(type) as IMiddleware;

                middleware.Next = handler;
                handler = middleware.Handle;
            }
            return handler;
        }
    }
}
