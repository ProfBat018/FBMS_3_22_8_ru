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
        var token = HttpContext.Request.Cookies["accessToken"];

        await accountService.ResetPaswordAsync(resetRequest, token);
        return Ok("Password successfully reseted");
    }


    [Authorize]
    [HttpPost("ConfirmEmail")]
    public async Task<IActionResult> ConfirmEmailAsync()
    {
        var token = HttpContext.Request.Cookies["accessToken"];

        await accountService.ConfirmEmailAsync(token);

        return Ok(new PostResponse("Mail Sent", 200));
    }

    [HttpGet("ValidateConfirmation")]
    public async Task<IActionResult> ValidateConfirmationAsync([FromQuery] string token)
    {
        await tokenService.ValidateEmailTokenAsync(token);

        return Ok("Email confirmed successfully");
    }
}