using System.Net;

namespace WebServer.Middlewares.Delegates;

// Этот делегат создал я сам 
public delegate void HttpHandler(HttpListenerContext context);


