using Microsoft.AspNetCore.Identity;

namespace ToDoApi.Models;

public class LoginUser
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}