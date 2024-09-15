using Asp.Versioning;
using AuthData.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Interfaces;

namespace AuthApiService.Controllers;

[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Authorize(Roles = "AppAdmin")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class RoleController : ControllerBase
{

    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet("All")]
    public async Task<IActionResult> GetAllRolesAsync()
    {
        var res = await _roleService.GetAllRolesAsync();

        return Ok(res);
    }

    [HttpPost("New")]
    public async Task AddNewRoleAsync([FromBody] RoleDTO role)
    {
        await _roleService.AddNewRoleAsync(role);
    }
    
    [HttpPost("Grant")]
    public async Task GrantRoleAsync([FromBody] GrantRoleDTO roleDto)
    {
        await _roleService.GrantRoleAsync(roleDto);
    }
    
}