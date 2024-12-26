using CommunicationService.Data.Models;

namespace CommunicationService.Services.Interfaces;

public interface INotificationService
{
    public Task<Notification> CreateNotificationAsync(string message, string ownerId);
    public Task SendNotificationAsync(Notification notification);
}
