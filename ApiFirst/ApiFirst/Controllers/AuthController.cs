using ApiFirst.Data.Contexts;
using ApiFirst.Data.Models;
using ApiFirst.Services.Classes;
using ApiFirst.Services.Interfaces;
using ApiFirst.Validators;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirst.Controllers;


[ApiController]
[Route("api/v1/[controller]")]
public class AuthController : ControllerBase
{
    private readonly LoginUserValidator loginValidator;
    private readonly RegisterUserValidator registerValidator;
    private readonly IAuthService authService;
    private readonly ITokenService tokenService;


    public AuthController(LoginUserValidator loginValidator, RegisterUserValidator registerValidator, IAuthService authService, ITokenService tokenService)
    {
        this.loginValidator = loginValidator;
        this.registerValidator = registerValidator;
        this.authService = authService;
        this.tokenService = tokenService;
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

            var tokenData = new TokenData()
            {
                AccessToken = await tokenService.GenerateTokenAsync(res),
                RefreshToken = await tokenService.GenerateRefreshTokenAsync(),
                RefreshTokenExpireTime = DateTime.Now.AddMinutes(35),
            };

            return Ok(tokenData);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
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
        catch (Exception ex)
        {

            throw;
        }
    }
}
