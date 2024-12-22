using System.Security.Claims;
using CommunicationService.DTO;
using CommunicationService.Services.Implenetations;
using CommunicationService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommunicationService.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize("AppUserOrAdmin")]
public class SubscribeController : ControllerBase
{
    private readonly ISubscribeService _subscribeService;

    public SubscribeController(ISubscribeService subscribeService)
    {
        _subscribeService = subscribeService;
    }

    [HttpPost("to")]
    public async Task<IActionResult> SubscribeAsync([FromBody] SubscribeRequestDTO requestDto)
    {
        var ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        await _subscribeService.SubscribeAsync(requestDto.username, ownerId);
        return Ok();
    }
}