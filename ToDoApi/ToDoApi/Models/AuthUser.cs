using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ToDoApi.Models;

public class AuthUser 
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    [NotMapped]
    public ICollection<UserTask> Tasks { get; set; }
}