using System.Text;
using Newtonsoft.Json;
using NotificationService.Data.Models;
using NotificationService.Services.Interfaces;
using RabbitMQ.Client;
     using RabbitMQ.Client.Events;
     
     namespace NotificationService.Services.Implementations;
     
     public class NotificationService : INotificationService
     {
         private readonly IConfiguration _configuration;
     
         public NotificationService(IConfiguration configuration)
         {
             _configuration = configuration;
         }
     
         public Task<Notification> ReceiveNotificationAsync()
         {
        var factory = new ConnectionFactory
        {
            HostName = _configuration["RabbitMQ:Host"],
            Port = 5672
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        var queueName = "notifications";
        channel.QueueDeclare(
            queue: queueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        
        Notification? notification = null;
        
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body); 
            notification = JsonConvert.DeserializeObject<Notification>(message);
        };

        channel.BasicConsume(
            queue: queueName,
            autoAck: true,
            consumer: consumer);
        
        return Task.FromResult(notification);
    }
}

