namespace CommunicationService.Data.Models;

    public class Subscriber
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid OwnerId { get; set; }
        
        public Guid SubscriberId { get; set; }
    }
