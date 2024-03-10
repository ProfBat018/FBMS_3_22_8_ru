using System.Net;

namespace WebServer.Services.Interfaces;

public interface IWebHost
{
    public void Start();
    public void HandleRequest(HttpListenerContext context);
}