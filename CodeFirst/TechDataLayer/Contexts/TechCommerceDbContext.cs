using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TechDataLayer;

public class TechCommerceDbContext : DbContext
{
    public TechCommerceDbContext()
    {
    }
    public TechCommerceDbContext(DbContextOptions<TechCommerceDbContext> options) : base(options)
    {
    }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}
