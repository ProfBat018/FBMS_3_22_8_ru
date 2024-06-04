using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;
using ToDoApi.Models.Contexts;

namespace ToDoApi.Controllers;

[Route("api/[controller]")]
[Authorize]
public class TasksController : ControllerBase
{
    private readonly TodoContext _todoContext;
    private readonly UserManager<IdentityUser> _userManager;


    private async Task<IdentityUser> GetUserAsync()
    {
        var userEmail = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
        
        if (userEmail is null)
        {
            throw new Exception("User email not found");
        }
        
        var user = await _userManager.FindByEmailAsync(userEmail);
        return user;
    }
    public TasksController(TodoContext todoContext, UserManager<IdentityUser> userManager)
    {
        _todoContext = todoContext;
        _userManager = userManager;
    }

    [HttpGet("GetAllTasks")]
    public async Task<IActionResult> GetAllTasksAsync()
    {
        return new JsonResult(new { Res = "This is test endpoint" });
    }

    [HttpGet("GetTaskById")]
    public async Task<IActionResult> GetTaskByIdAsync()
    {

        var user = await GetUserAsync();
        
        var tasks = await _todoContext.Tasks.Where(x => x.UserId == user.Id).ToListAsync();

        return new JsonResult(tasks, new JsonSerializerOptions()
        {
            WriteIndented = true
        });
    }
    
    [HttpPost("AddTask")]
    public async Task<IActionResult> AddTaskAsync([FromBody] UserTask task)
    {
        var user = await GetUserAsync();

        task.UserId = user.Id;
        
        await _todoContext.Tasks.AddAsync(task);
        
        await _todoContext.SaveChangesAsync();

        return Ok();
    }
    
    
}