using Microsoft.EntityFrameworkCore;

namespace LINQ1.Services;

public interface IDataConnectionService
{
    public DbContextOptions<T> Configure<T>(string connectionName) where T : DbContext;
}