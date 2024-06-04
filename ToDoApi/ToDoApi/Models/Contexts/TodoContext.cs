using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ToDoApi.Models.Contexts;

public class TodoContext : IdentityDbContext
{
    public DbSet<UserTask> Tasks { get; set; }

    public TodoContext(DbContextOptions<TodoContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        var toDoEntity = builder.Entity<UserTask>();
        var userEntity = builder.Entity<IdentityUser>();
        
        userEntity.Property(x => x.UserName).IsRequired();
        userEntity.Property(x => x.Email).IsRequired();
        
        toDoEntity.HasKey(t => t.Id);
        base.OnModelCreating(builder);
    }
}