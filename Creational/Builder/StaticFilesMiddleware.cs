using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Builder;

public class StaticFilesMiddleware : IMiddleware
{
    public void HandleRequest(string context)
    {
        Console.WriteLine("Thi is static files middleware");
        Next?.Invoke(context);
    }
    public Handler Next { get; set; }
}
