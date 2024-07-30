using ApiFirst.Data.Contexts;
using ApiFirst.Data.Models;
using ApiFirst.Exceptions;
using ApiFirst.Services.Classes;
using ApiFirst.Services.Interfaces;
using ApiFirst.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirst.Controllers;


[ApiController]
[Route("api/v1/[controller]")]
public class AuthController : ControllerBase
{
    private readonly LoginUserValidator loginValidator;
    private readonly RegisterUserValidator registerValidator;
    private readonly IAuthService authService;


    public AuthController(LoginUserValidator loginValidator, RegisterUserValidator registerValidator, IAuthService authService)
    {
        this.loginValidator = loginValidator;
        this.registerValidator = registerValidator;
        this.authService = authService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginUser user)
    {
        var validationResult = loginValidator.Validate(user);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        try
        {
            var res = await authService.LoginUserAsync(user);

            return Ok(res);
        }
        catch (MyAuthException ex)
        {
            return BadRequest($"{ex.Message}\n{ex.AuthErrorType}");
        }
    }

    [HttpPost("Register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterUser user)
    {
        try
        {
            var validationResult = registerValidator.Validate(user);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var res = await authService.RegisterUserAsync(user);
            return Ok(res);
        }
        catch (MyAuthException ex)
        {
            return BadRequest($"{ex.Message}\n{ex.AuthErrorType}");
        }
    }


    [HttpPost("Refresh")]
    public async Task<IActionResult> RefreshTokenAsync(UserTokenInfo refresh)
    {
        try
        {
            var newToken = await authService.RefreshTokenAsync(refresh);

            if (newToken is null)
                return BadRequest("Invalid token");

            return Ok(newToken);
        }
        catch (MyAuthException ex)
        {
            return BadRequest($"{ex.Message}\n{ex.AuthErrorType}");
        }

    }


    [Authorize]
    [HttpPost("Logout")]
    public async Task<IActionResult> LogoutAsync(UserTokenInfo logout)
    {
        try
        {
            await authService.LogOutAsync(logout);
            return Ok("Logged out successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
