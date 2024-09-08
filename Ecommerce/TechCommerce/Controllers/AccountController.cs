using Microsoft.AspNetCore.Mvc;

namespace TechCommerce.Controllers;

public class AccountController : Controller
{
    // GET
    public IActionResult SignIn()
    {
        return View();
    }
}