using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Services.Classes;
using WebServer.Services.Interfaces;

namespace WebServer.Controllers
{
    public class InfoController : Controller
    {
        public LoggerService Logger { get; set; }
        public InfoController(LoggerService? logger)
        {
            Logger = logger;
        }

        public IActionResult Index()
        {
            Logger.Log("This is Index from InfoController Index method...");
            return base.View();
        }

        public IActionResult Data()
        {
            return base.Json(new { Name = "Orxan", Surname = "Salaxatdinov", Age = 18 });
        }
    }
}
