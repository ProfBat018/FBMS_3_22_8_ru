using AuthData.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthData.Contexts;

public class AuthContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public AuthContext()
    {
        
    }

    public AuthContext(DbContextOptions<AuthContext> options): base(options)
    {
        
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var userEntity = modelBuilder.Entity<User>();

        userEntity.HasKey(u => u.Id); // primary key

        userEntity.Property(u => u.Username)
            .IsRequired();
        userEntity.HasIndex(u => u.Username)
            .IsUnique();

        userEntity.Property(u => u.Email)
            .IsRequired();
        userEntity.HasIndex(u => u.Email)
            .IsUnique();

        userEntity.Property(u => u.Password)
            .IsRequired();
    }



}
