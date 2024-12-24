using CommunicationService.Data.Contexts;
using CommunicationService.Data.Models;
using CommunicationService.Services.Interfaces;
using Grpc.Net.Client;
using CommunicationService.Protos.GrpcUserService;


namespace CommunicationService.Services.Implenetations;

public class SubscribeService : ISubscribeService
{
    private readonly CommunicationContext _context;
    private readonly UserService.UserServiceClient _userServiceClient;
    
    public SubscribeService(CommunicationContext context, UserService.UserServiceClient userServiceClient)
    {
        _context = context;
        _userServiceClient = userServiceClient;
    }

    public async Task SubscribeAsync(string userName, string ownerId)
    {
        var userResponse = await _userServiceClient.GetIdByUsernameAsync(new UserRequest
        {
            Username = userName
        });
        
        var subscriber = new Subscriber
        {
            SubscriberId = Guid.Parse(userResponse.Id),
            OwnerId = Guid.Parse(ownerId)
        };
        
        await _context.Subscribers.AddAsync(subscriber);
        
        await _context.SaveChangesAsync();
    }

    public Task UnsubscribeAsync(string userName, string ownerId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Subscriber>> GetSubscribersAsync()
    {
        throw new NotImplementedException();
    }
}