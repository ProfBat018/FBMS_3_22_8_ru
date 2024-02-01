using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TechDataLayer;

namespace LINQ1.Services;

public class DataConnectionService : IDataConnectionService
{
    private readonly IConfigurationBuilder _builder;
    public DataConnectionService(IConfigurationBuilder builder)
    {
        _builder = builder;
    }

    public DbContextOptions<T> Configure<T>(string connectionName) where T : DbContext
    {
        _builder.AddJsonFile("appsettings.json");
        
        var config = _builder.Build();
        
        var connectionString = config.GetConnectionString(connectionName);

        var opsBuilder = new DbContextOptionsBuilder<T>().UseSqlServer(connectionString); 
       
        return opsBuilder.Options;
    }
}