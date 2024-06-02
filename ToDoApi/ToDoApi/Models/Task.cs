namespace ToDoApi.Models;

public class Task
{
    public string Id { get; } = Guid.NewGuid().ToString();
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
    public bool IsDone { get; set; }
}


