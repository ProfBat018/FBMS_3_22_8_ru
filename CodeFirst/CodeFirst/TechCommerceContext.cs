using Microsoft.EntityFrameworkCore;

namespace CodeFirst;

public class TechCommerceContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=TechCommerceDb;User Id=sa; Password=Elvin123;Trust Server Certificate=true;");
    }
}