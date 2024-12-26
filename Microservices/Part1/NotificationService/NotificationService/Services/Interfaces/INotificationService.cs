using NotificationService.Data.Models;

namespace NotificationService.Services.Interfaces;

public interface INotificationService
{
    public Task<Notification> ReceiveNotificationAsync();
}