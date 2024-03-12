using WebServer.Middlewares.Delegates;
using WebServer.Middlewares.Interfaces;

namespace WebServer.Middlewares.Classes;

// LoggerMiddleware
// MvcMiddleware

public class MiddlewareBuilder
{
    private Stack<Type> middlewares = new(); // LIFO

    public void Use<T>() where T : IMiddleware
    {
        middlewares.Push(typeof(T));
    }

    public HttpHandler Build()
    {
        HttpHandler handler = context => context.Response.Close(); // LAST

        while (middlewares.Count != 0)
        {
            var type = middlewares.Pop();
            var middleware = Activator.CreateInstance(type) as IMiddleware;

            middleware.Next = handler;
            handler = middleware.Handle;
        }
        return handler;
    }
}
