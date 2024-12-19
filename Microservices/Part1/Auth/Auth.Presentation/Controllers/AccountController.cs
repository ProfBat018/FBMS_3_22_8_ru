
using Asp.Versioning;
using Auth.Application.DTO;
using Auth.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Presentation.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize]
public class AccountController : ControllerBase
{
    private readonly IAccountService accountService;
    private readonly ITokenService tokenService;

    public AccountController(IAccountService accountService, ITokenService tokenService)
    {
        this.accountService = accountService;
        this.tokenService = tokenService;
    }

  
    [HttpPost("ResetPassword")]
    public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordDTO resetRequest)
    {
        var token = HttpContext.Request.Cookies["accessToken"];

        await accountService.ResetPaswordAsync(resetRequest, token);
        return Ok("Password successfully reseted");
    }

  
    [HttpPost("ConfirmEmail")]
    public async Task<IActionResult> ConfirmEmailAsync()
    {
        var token = HttpContext.Request.Cookies["accessToken"];
        await accountService.ConfirmEmailAsync(token);

        return Ok(new PostResponse("Mail Sent", 200));
    }

    [HttpGet("ValidateConfirmation")]
    [AllowAnonymous]
    public async Task<IActionResult> ValidateConfirmationAsync([FromQuery] string token)
    {
        var res = await tokenService.ValidateEmailTokenAsync(token);

        return Ok(res);
    }
}
