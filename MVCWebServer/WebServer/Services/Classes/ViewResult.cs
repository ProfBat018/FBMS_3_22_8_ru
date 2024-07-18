using System.Net;
using WebServer.Services.Interfaces;


namespace WebServer.Services.Classes
{
    public class ViewResult : IActionResult
    {
        public void ExecuteResult(HttpListenerContext? context)
        {
            var parts = context.Request.RawUrl.Split('/', StringSplitOptions.RemoveEmptyEntries);

            var controllerName = parts[0];
            var methodName = parts[1];
            var path = $"Views/{methodName}.html";
            var bytes = File.ReadAllBytes(path);
            context.Response.ContentType = "text/html";
            context.Response.OutputStream.Write(bytes, 0, bytes.Length);
        }
    }
}
