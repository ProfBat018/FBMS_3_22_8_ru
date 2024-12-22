using CommunicationService.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommunicationService.Data.Config;

public class SubscriberConfiguration : IEntityTypeConfiguration<Subscriber>
{
    public void Configure(EntityTypeBuilder<Subscriber> builder)
    {
        builder.ToTable("Subscribers");
        
        builder.HasKey(s => s.Id);

        builder.Property(s => s.OwnerId)
            .IsRequired();
        
        builder.Property(s => s.SubscriberId)
            .IsRequired();
        
        builder.HasIndex(s => new { s.OwnerId, s.SubscriberId })
            .IsUnique()
            .HasDatabaseName("IX_Subscribers_OwnerId_SubscriberId");
    }
}