using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Mvc;
using Prometheus;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    private static readonly Counter SuccessfulAuthCounter = Metrics.CreateCounter("test_count", "Test counter");

    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("Test");
    }
}