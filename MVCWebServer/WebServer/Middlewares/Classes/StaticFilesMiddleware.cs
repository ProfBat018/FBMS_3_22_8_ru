using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebServer.Middlewares.Interfaces;

namespace WebServer.Middlewares.Classes
{
    public class StaticFilesMiddleware : IMiddleware
    {
        public HttpHandler Next { get; set; }

        public void Handle(HttpListenerContext context)
        {
            string url = context.Request.RawUrl;
            Console.WriteLine(url);

            Next.Invoke(context);
        }
    }
}
