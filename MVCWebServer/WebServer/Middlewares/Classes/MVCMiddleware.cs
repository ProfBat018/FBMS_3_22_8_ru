using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Reflection;
using System.Text;
using WebServer.Controllers;
using WebServer.Middlewares.Interfaces;
using WebServer.Services.Classes;

namespace WebServer.Middlewares.Classes
{
    public class MVCMiddleware : IMiddleware // class
    {
        public HttpHandler Next { get; set; } // delegate
        public void Handle(HttpListenerContext context)
        {
            // localhost:5000/Home/Index
            // RawUrl = /Home/Index
            // After split = {[0] = Home, [1] = Index }
            
            string[] parts = context.Request.RawUrl.Split('/', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 1)
            {
                return; // На случай, если пользователь ввел только localhost:5000/Home
            }

            StringBuilder builder = new("WebServer.Controllers.");
            
            builder.Append(parts[0]);
            builder.Append("Controller");

            // WebServer.Controllers.HomeController
            
            string controllerName = builder.ToString();
            
            
            // Index
            string methodName = parts[1].Split('?')[0];

            // Assembly - класс, который представляет сборку
            
            Assembly currentAssembly = Assembly.GetExecutingAssembly(); // Получаем текущую сборку
            
            Type? controllerType = currentAssembly.GetType(controllerName); // рефлексия

            if (controllerType != null)
            {
                // Забираем из контейнера нужный нам контроллер
                Controller controllerObj = WebHost.Container.GetRequiredService(controllerType) as Controller;
                
                controllerObj.Context = context;

                MethodInfo controllerMethod = controllerType.GetMethod(methodName); // рефлексия, получаем метод контроллера

                if (controllerMethod != null)
                {
                    ParameterInfo[] parameters = controllerMethod.GetParameters(); // рефлексия, получаем параметры метода

                    object[] paramValues = new object[parameters.Length]; // значения параметров

                    
                    // Example query - localhost:5000/Home/Index?name=Vasya&age=20
                    int i = 0;
                    foreach (var item in parameters)
                    {
                        paramValues[i++] = Convert.ChangeType(context.Request.QueryString[item.Name], item.ParameterType);
                    }
                    controllerMethod.Invoke(controllerObj, paramValues);
                }
            }
            Next.Invoke(context);
        }
    }
}
