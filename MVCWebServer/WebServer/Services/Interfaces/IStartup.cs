using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Middlewares.Classes;

namespace WebServer.Services.Interfaces
{
    public interface IStartup
    {
        public void Configure(IServiceCollection serviceCollection);
        public void ConfigureMiddleware(MiddlewareBuilder builder);
    }
}
