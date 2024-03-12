using System.Net;
using WebServer.Services.Classes.Results;

namespace WebServer.Controllers;

public class Controller
{
    public HttpListenerContext Context { get; set; }

    public JsonResult Json(object data)
    {
        var result = new JsonResult(data);
        result.ExecuteResult(Context);
        return result;
    }
}
