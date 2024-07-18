using System.Net;

namespace WebServer.Services.Classes
{
    public class Controller
    {
        public HttpListenerContext Context { get; set; }

        public JsonResult Json(object? data)
        {
            if (data != null)
            {
                var result = new JsonResult(data);
                result.ExecuteResult(Context);

                return result;
            }
            throw new NullReferenceException();

        }
        public ViewResult View()
        {
            var result = new ViewResult();
            result.ExecuteResult(Context);
            return result;
        }

        public MyHttpResult HttpRes()
        {
            var result = new MyHttpResult();
            result.ExecuteResult(Context);
            return result;
        }
    }
}
