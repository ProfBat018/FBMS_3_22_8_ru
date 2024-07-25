using ApiFirst.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiFirst.Data.Contexts;

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
            .IsRequired()
            .HasMaxLength(50);
        userEntity.HasIndex(u => u.Username)
            .IsUnique();

        userEntity.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(50);
        userEntity.HasIndex(u => u.Email)
            .IsUnique();

        userEntity.Property(u => u.Password)
            .IsRequired();
    }



}
