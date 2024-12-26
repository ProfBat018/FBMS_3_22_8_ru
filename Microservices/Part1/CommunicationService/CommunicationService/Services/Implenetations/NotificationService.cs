using System.Text;
using CommunicationService.Data.Models;
using CommunicationService.Services.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace CommunicationService.Services.Implenetations;

public class NotificationService : INotificationService
{
    
    private readonly IConfiguration _configuration;

    public NotificationService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Task<Notification> CreateNotificationAsync(string message, string ownerId)
    {
            var notification = new Notification
            {
                Message = message,
                OwnerId = Guid.Parse(ownerId)
            };
            
            return Task.FromResult(notification);
    }

    public async Task SendNotificationAsync(Notification notification)
    {
        var factory = new ConnectionFactory() { HostName = _configuration["RabbitMQ:HostName"], Port = Convert.ToInt32(_configuration["RabbitMQ:Port"]) };
        using var connection =  factory.CreateConnection();
        using var channel = connection.CreateModel();
        
        channel.QueueDeclare(queue: "notifications",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);
        
        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(notification));
        
        channel.BasicPublish(exchange: "",
            routingKey: "notifications",
            basicProperties: null,
            body: body);
    }
}