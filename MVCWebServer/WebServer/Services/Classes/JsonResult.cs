using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebServer.Services.Interfaces;

namespace WebServer.Services.Classes
{
    public class JsonResult : IActionResult
    {
        public object Data { get; set; }
        public JsonResult(object data)
        {
            Data = data;
        }

        public void ExecuteResult(HttpListenerContext context)
        {
            var json = JsonConvert.SerializeObject(Data, Formatting.Indented);
            var bytes = Encoding.UTF8.GetBytes(json);
            
            context.Response.ContentType = "application/json";
            context.Response.OutputStream.Write(bytes, 0, bytes.Length);
        }
    }
}
