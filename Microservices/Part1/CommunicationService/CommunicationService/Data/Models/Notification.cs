namespace CommunicationService.Data.Models;

public class Notification
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Message { get; set; }
    public Guid OwnerId { get; set; }
    
    public object? Data { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}


