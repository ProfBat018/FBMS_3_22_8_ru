using Asp.Versioning;
using AuthData.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UserService.Exceptions;
using UserService.Interfaces;
using UserService.Validators;

namespace AuthApiService.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class AuthController : ControllerBase
{
    private readonly LoginUserValidator loginValidator;
    private readonly RegisterUserValidator registerValidator;
    private readonly IAuthService authService;


    public AuthController(LoginUserValidator loginValidator, RegisterUserValidator registerValidator,
        IAuthService authService)
    {
        this.loginValidator = loginValidator;
        this.registerValidator = registerValidator;
        this.authService = authService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginDTO user)
    {
        var validationResult = loginValidator.Validate(user);

        if (!validationResult.IsValid)
        {
            throw new MyAuthException(AuthErrorTypes.InvalidCredentials,
                JsonConvert.SerializeObject(validationResult.Errors, Formatting.Indented));
        }

        var res = await authService.LoginUserAsync(user);

        return Ok(res);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterDTO user)
    {
        var validationResult = registerValidator.Validate(user);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var res = await authService.RegisterUserAsync(user);
        return Ok(res);
    }


    [HttpPost("Refresh")]
    public async Task<IActionResult> RefreshTokenAsync(TokenDTO refresh)
    {
        var newToken = await authService.RefreshTokenAsync(refresh);

        if (newToken is null)
            return BadRequest("Invalid token");

        return Ok(newToken);
    }


    [Authorize]
    [HttpPost("Logout")]
    public async Task<IActionResult> LogoutAsync(TokenDTO logout)
    {
        await authService.LogOutAsync(logout);
        return Ok("Logged out successfully");
    }
}