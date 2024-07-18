using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Services.Classes
{
    public class LoggerService
    {
        public void Log(string text)
        {
            Console.WriteLine(text);
        }
    }
}
