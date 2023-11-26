using Builder;
using System.Net;


public interface IMiddleware
{
    public void HandleRequest(string context)
    {
        Console.WriteLine(context);
        Console.WriteLine("Elnur dvoecnik )) ");
    }
    public Handler Next { get; set; }
}






