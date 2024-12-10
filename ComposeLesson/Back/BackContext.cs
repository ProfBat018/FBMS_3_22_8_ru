using Microsoft.EntityFrameworkCore;

namespace Back;

public class BackContext : DbContext
{
    public DbSet<Forecast> Forecasts { get; set; }

    public BackContext(DbContextOptions<BackContext> ops) : base(ops)
    {
       
    }
    
    
}