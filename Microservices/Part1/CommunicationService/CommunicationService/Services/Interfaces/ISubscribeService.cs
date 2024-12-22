using CommunicationService.Data.Models;

namespace CommunicationService.Services.Interfaces;

public interface ISubscribeService
{
    public Task SubscribeAsync(string UserName, string ownerId);
    public Task UnsubscribeAsync(string userName, string ownerId);
    public Task<IEnumerable<Subscriber>> GetSubscribersAsync();
}