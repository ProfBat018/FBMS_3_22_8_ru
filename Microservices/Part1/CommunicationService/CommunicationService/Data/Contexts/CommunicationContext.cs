using CommunicationService.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunicationService.Data.Contexts;

public class CommunicationContext : DbContext
{
    public DbSet<Subscriber> Subscribers { get; set; }

    public CommunicationContext(DbContextOptions<CommunicationContext> ops) : base(ops)
    {
        
    }

}
