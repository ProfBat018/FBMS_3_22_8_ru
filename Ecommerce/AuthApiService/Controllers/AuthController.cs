using System.Net;
using System.Reflection.Metadata.Ecma335;
using Asp.Versioning;
using AuthData.Configs;
using AuthData.DTO;
using AutoMapper;
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

    [AllowAnonymous]
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
        

        Response.Cookies.Append("accessToken", res.accessToken);
        Response.Cookies.Append("refreshToken", res.refreshToken);
        
        return Ok(new LoginResponse_DTO(res.userName));
    }

    [AllowAnonymous]
    [HttpPost("Register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterDTO user)
    {
        var validationResult = registerValidator.Validate(user);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var res = await authService.RegisterUserAsync(user);
        
        return Ok(new PostResponse("Registration comleted"));
    }

    
    [HttpPost("Refresh")]
    public async Task<IActionResult> RefreshTokenAsync(TokenDTO tokenDto)
    {
        var newToken = await authService.RefreshTokenAsync(tokenDto);

        if (newToken is null)
            return BadRequest("Invalid token");

        return Ok(newToken);
    }


    [Authorize]
    [HttpPost("Logout")]
    public async Task<IActionResult> LogoutAsync()
    {
        if (!Request.Cookies.ContainsKey("accessToken") && !Request.Cookies.ContainsKey("refreshToken"))
        {
            return Ok(new PostResponse("Please log in for logging out", 404));
        }
        
        var logoutInfo = new TokenDTO(Request.Cookies["accessToken"], Request.Cookies["refreshToken"]);
        await authService.LogOutAsync(logoutInfo);
        
        Response.Cookies.Delete("accessToken");
        Response.Cookies.Delete("refreshToken");
        
        return Ok(new PostResponse("Logged out successfully", 200));
    }
}