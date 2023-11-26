using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Builder;

class ImageMiddleware : IMiddleware
{
    public void HandleRequest(string context)
    {
        Console.WriteLine("This is image middleware");
        Next?.Invoke(context);
    }
    public Handler Next { get; set; }
}
