using Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace Auth.Contexts;

public class UserContext :  DbContext
{
    public UserContext()
    {
    }

    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }

    // FluentApi
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var user = modelBuilder.Entity<User>();

        user.HasKey(u => u.Id); // primary key

        user.Property(x => x.Email)
            .IsRequired() // not null
            .HasMaxLength(50); // max length

        user.HasIndex(x => x.Email).IsUnique(); // unique

        user.Property(x => x.Password)
            .IsRequired();
    }

    public DbSet<User> Users { get; set; }
}