using Asp.Versioning;

using AuthData.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Exceptions;
using UserService.Interfaces;

namespace AuthApiService.Controllers;
    
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService accountService;
    private readonly ITokenService tokenService;

    public AccountController(IAccountService accountService, ITokenService tokenService)
    {
        this.accountService = accountService;
        this.tokenService = tokenService;
    }

    [Authorize]
    [HttpPost("ResetPassword")]
    public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordDTO resetRequest)
    {
        var token = HttpContext.Request.Headers["Authorization"];

        token = token.ToString().Replace("Bearer ", "");

        await accountService.ResetPaswordAsync(resetRequest, token);
        return Ok("Recovery link sent to your email");
    }


    [Authorize]
    [HttpPost("ConfirmEmail")]
    public async Task<IActionResult> ConfirmEmailAsync()
    {
        var token = HttpContext.Request.Headers["Authorization"];

        token = token.ToString().Replace("Bearer ", "");

        await accountService.ConfirmEmailAsync(token);

        return Ok();
    }

    [HttpGet("ValidateConfirmation")]
    public async Task<IActionResult> ValidateConfirmationAsync([FromQuery] string token, [FromQuery] string userId)
    {
        await tokenService.ValidateEmailTokenAsync(token, userId);

        return Ok("Email confirmed successfully");
    }
}