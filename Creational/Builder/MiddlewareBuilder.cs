using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Builder;

public class MiddlewareBuilder
{
    private Stack<Type> middlewares = new();

    public void Use<T>() where T : IMiddleware
    {
        middlewares.Push(typeof(T));
    }

    public Handler Build()
    {
        Handler handler = context => Console.WriteLine("End of pipeline");

        while (middlewares.Count != 0)
        {
            Type type = middlewares.Pop();

            var middleware = Activator.CreateInstance(type) as IMiddleware;

            middleware.Next = handler;
            handler = middleware.HandleRequest;
        }
        return handler;
    }


}
