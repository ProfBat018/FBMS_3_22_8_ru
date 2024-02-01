using FluentApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FluentApi.Data.Contexts;

public class TechCommerceDbContext : DbContext
{
    // Этот констркутор нужен для использования объекта в коде
    // Например 
    // using var db = new TechCommerceDbContext()
    public TechCommerceDbContext()
    {
        
    }

    // Этот конструктор нужен для создания конфигурации, например добавление 
    // connectionString 
    public TechCommerceDbContext(DbContextOptions<TechCommerceDbContext> ops)
        : base(ops)
    {
        
    }
    
    // DbSet - это коллекция объектов, которые будут храниться в базе данных
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    
    // OnModelCreating - это метод, который называется FluentApi. 
    // По сути это замена для аннотаций, которые мы использовали в прошлом проекте

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var productEntity = modelBuilder.Entity<Product>();
        var categoryEntity = modelBuilder.Entity<Category>();
        
        categoryEntity.HasKey(x => x.Id);
        categoryEntity.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(30);
        
        categoryEntity
            .HasMany(x => x.Products)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId);    
       
        //--------------------------------------------
        
        productEntity.HasKey(x => x.Id);
        productEntity
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(30);
        productEntity
            .Property(x => x.Price)
            .IsRequired()
            .HasColumnType("smallmoney");

    }
}