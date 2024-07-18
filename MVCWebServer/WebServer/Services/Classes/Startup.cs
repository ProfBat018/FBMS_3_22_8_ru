using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Controllers;
using WebServer.Middlewares.Classes;
using WebServer.Services.Interfaces;

namespace WebServer.Services.Classes
{
    public class Startup : IStartup
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            // Добавляю все сервисы и Middleware в свой IOC Container
            serviceCollection.AddTransient<LoggerMiddleware>(); // var logger = new LoggerMiddleware(); 
            serviceCollection.AddTransient<HomeController>();
            serviceCollection.AddTransient<InfoController>();

            serviceCollection.AddTransient<LoggerService>();
            serviceCollection.AddTransient<MVCMiddleware>();
            serviceCollection.AddTransient<StaticFilesMiddleware>();
        }
        
        public void ConfigureMiddleware(MiddlewareBuilder builder)
        {
            // Вспомните паттерн builder. Builder - это паттерн, который позволяет строить большие объекты пошагово. 
            builder.Use<MVCMiddleware>();
            builder.Use<LoggerMiddleware>();
            builder.Use<StaticFilesMiddleware>();
        }
    }
}

