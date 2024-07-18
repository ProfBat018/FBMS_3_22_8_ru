using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Services.Classes;
using WebServer.Services.Interfaces;

namespace WebServer.Controllers
{
    public class HomeController : Controller
    {
        public LoggerService Logger { get; set; }
       
        public HomeController(LoggerService logger)
        {
            Logger = logger;
        }

        public IActionResult Index()
        {
            Logger.Log("This is Index from HomeController Index method...");
            return base.View();
        }

        public IActionResult Data()
        {
            return base.Json(new { Name = "Elvin", Surname = "Azimov", Age = 21 });
        }

        public IActionResult GetResponse()
        {
            return base.HttpRes();
        }
    }
}
