using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApi.Models;

public class UserTask
{
    public string Id { get; } = Guid.NewGuid().ToString();
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
    public bool IsDone { get; set; }
    
    
    [ForeignKey("User")]
    public string UserId { get; set; }
    public AuthUser User { get; set; }
}


