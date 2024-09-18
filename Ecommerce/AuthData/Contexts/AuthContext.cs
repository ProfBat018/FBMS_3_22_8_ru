using AuthData.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthData.Contexts;

public class AuthContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<AppRole> AppRoles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    public AuthContext()
    {
    }

    public AuthContext(DbContextOptions<AuthContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var userEntity = modelBuilder.Entity<User>();
        var appRoleEntity = modelBuilder.Entity<AppRole>();
        var userRoleEntity = modelBuilder.Entity<UserRole>();

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


        appRoleEntity.HasKey(a => a.Id);
        appRoleEntity.Property(a => a.Name).IsRequired();
        appRoleEntity.HasIndex(a => a.Name).IsUnique();

        userRoleEntity.HasKey(u => u.Id);

        userRoleEntity
            .HasOne(ur => ur.AppRole)
            .WithMany(ar => ar.UserRoles) // Связь с коллекцией UserRoles в AppRole
            .HasForeignKey(ur => ur.RoleId) // Связь по RoleId
            .OnDelete(DeleteBehavior.Cascade); // Поведение при удалении

        // Настройка внешнего ключа на User (UserId)
        userRoleEntity
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles) // Связь с коллекцией UserRoles в User
            .HasForeignKey(ur => ur.UserId) // Связь по UserId
            .OnDelete(DeleteBehavior.Cascade); // Поведение при удалении
    }
}