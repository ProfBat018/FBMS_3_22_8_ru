using Microsoft.AspNetCore.Mvc;

namespace Movies.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase 
{
    // GET
    public IActionResult Index()
    {
        return Ok("Hello World");
    }
}