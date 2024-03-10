using System.Net;
using System.Text;
using Newtonsoft.Json;
using WebServer.Services.Interfaces;

namespace WebServer.Services.Classes.Results;


#region Docs
/*
 
    var json = JsonConvert.SerializeObject(Data, Formatting.Indented);
    Сериализую  объект в json, с помощью класса JsonConvert из бибилотеки NewtonSoftJson
    Formatting.Indented нужен для того чтобы были нормальные отступы в json, а не просто каша из текста. 
    
    var bytes = Encoding.UTF8.GetBytes(json);
    Конвертирую полученные json в байты 
    
    context.Response.ContentType = "application/json";
    Говорю своему контексту что тип данных, который я сейчас пошлю будет json 
    
    context.Response.OutputStream.Write(bytes, 0, bytes.Length);
    Записываю в ответный поток свои байты с 0 индекса до конца 
*/
#endregion

public class JsonResult : IActionResult
{
    public object Data { get; set; }
    
    public JsonResult(object? data)
    {
        if (data != null)
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