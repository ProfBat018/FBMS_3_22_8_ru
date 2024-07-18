using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Services.Interfaces
{
    public interface IActionResult
    {
        public void ExecuteResult(HttpListenerContext context);
    }
}
