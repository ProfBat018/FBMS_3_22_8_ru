using System.Net;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using WebServer.Controllers;
using WebServer.Middlewares.Classes;
using WebServer.Services.Classes.Endpoints;
using WebServer.Services.Interfaces;

namespace WebServer.Services.Classes.MainJobs;

public class WebHost : IWebHost
{
    public static ServiceProvider Container;
    private readonly MiddlewareBuilder _builder;
    private readonly HttpListener _listener;
    private ushort _port;

    public WebHost(ushort port)
    {
        _port = port;
        _listener = new();
        _builder = new();
    }

    private void ConfigureServices()
    {
        var collection = new ServiceCollection();

        collection.AddTransient<LoggerMiddleware>();
        collection.AddTransient<MiddlewareBuilder>();
        collection.AddTransient<MvcMiddleware>();
        collection.AddTransient<HomeController>();
        
        _builder.Use<LoggerMiddleware>();
        _builder.Use<MvcMiddleware>();
        
        Container = collection.BuildServiceProvider();
    }
    
    public void Start()
    {
        _listener.Prefixes.Add($"http://localhost:{_port}/");
        _listener.Start();
        
        Console.WriteLine($"Server started on port: {_port}");

        while (true)
        {
            ConfigureServices();
            HttpListenerContext context = _listener.GetContext();

            HandleRequest(context);
        }
    }

    public void HandleRequest(HttpListenerContext context)
    {
        var handler = _builder.Build();
        handler.Invoke(context);
    }
    
    #region OldHandleRequest

    /*

    public void HandleRequest(HttpListenerContext context)
    {
        var parts = context.Request.RawUrl.Split('/', StringSplitOptions.RemoveEmptyEntries);
        
        var assembly = Assembly.GetExecutingAssembly();

        var endpoints = assembly.GetTypes().Where(x => typeof(IEndpoint).IsAssignableFrom(x));

        string? endpointName = null;
        foreach (var item in endpoints)
        {
            if (parts[0] == item.Name)
            {
                endpointName = item.Name;
                break;
            }
        }

        if (endpointName == null)
            throw new Exception("Path is wrong");

        var endpointType = assembly.GetType($"WebServer.Services.Classes.Endpoints.{endpointName}");
        
        var method = endpointType.GetMethod(parts[1]);

        var obj = Activator.CreateInstance(endpointType) as Car;
        var res = method?.Invoke(obj, null) as List<Automobile>;

        var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(res, Formatting.Indented));
        
        context.Response.ContentType = "application/json";

        context.Response.OutputStream.Write(bytes, 0, bytes.Length);
        
        context.Response.Close();
    }
    */
    #endregion
}