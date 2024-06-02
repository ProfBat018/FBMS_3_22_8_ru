using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;
using ToDoApi.Services.Interfaces;

namespace ToDoApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> RegisterUser(LoginUser user)
    {
        if (await _authService.RegisterUser(user))
        {
            return Ok("Successfuly done");
        }

        return BadRequest("Something went wrong");
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginUser user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        if (await _authService.Login(user))
        {
            var tokenString = _authService.GenerateTokenString(user);
            return Ok(tokenString);
        }

        return BadRequest();
    }
}