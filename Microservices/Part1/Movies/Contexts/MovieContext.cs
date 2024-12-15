using Microsoft.EntityFrameworkCore;
using Movies.Models;

namespace Movies.Contexts;

public class MovieContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }

    public MovieContext(DbContextOptions<MovieContext> ops) : base(ops)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieContext).Assembly); // Reflection
    }
}