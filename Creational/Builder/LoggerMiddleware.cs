using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Builder;

public class LoggerMiddleware : IMiddleware
{
    public Handler Next { get; set; }

    public void HandleRequest(string context)
    {
        Console.WriteLine($"{DateTime.Now}: {context}");
        Next?.Invoke(context);
    }
}

