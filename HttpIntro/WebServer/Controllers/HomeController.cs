using WebServer.Services.Classes.Results;
using WebServer.Services.Interfaces;

namespace WebServer.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return base.Json(new
        {
            Name = "Elvin",
            Surname = "Azimov"
        });
    }
}