using Microsoft.Extensions.DependencyInjection;
using System.Net;
using WebServer.Middlewares.Classes;

namespace WebServer.Services.Classes
{
    public class WebHost
    {
        private Startup _startup;
        public static ServiceProvider Container; // Именно этот класс забирает объекты из IServiceCollection
        private HttpListener _listener; // Класс для прослушивания http запросов и их отправки  
        private ushort _port; // Порт прослушивания который я принимаю в конструктор 
        private MiddlewareBuilder _builder; // Передаю этот объект в Startup для добавления нужных Middleware 

        public WebHost(ushort port)
        {
            _port = port;
            _listener = new();
            _builder = new();
            _startup = new();
        }

        public void UserStartup()
        {
            var collection = new ServiceCollection();

            _startup.Configure(collection);
            Container = collection.BuildServiceProvider();
        }

        public void Start()
        {
            _listener.Prefixes.Add($"http://localhost:{_port}/");
            _listener.Start();
            Console.WriteLine($"Server started on port: {_port}");


            while (true)
            {
                this.UserStartup();
                _startup.ConfigureMiddleware(_builder);
                
                HttpListenerContext context = _listener.GetContext();

                HandleRequest(context);
            }
        }

        public void HandleRequest(HttpListenerContext context)
        {
            var handler = _builder.Build();
            handler.Invoke(context);
        }
    }
}
