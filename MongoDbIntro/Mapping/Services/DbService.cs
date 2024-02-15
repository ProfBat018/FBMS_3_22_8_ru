using System.Reflection;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Entities;

namespace Mapping.Services;

public class DbService
{
    private readonly MongoClient _dbConnection;

    public DbService()
    {
        var connectionString = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json").Build().GetConnectionString("Showroom");

        _dbConnection = new MongoClient(connectionString);
        
        InitCollections();
    }
    
    private void InitCollections()
    {
        var db = _dbConnection.GetDatabase("Showroom");

        var dbCollections = db.ListCollectionNames();
        var myCollections = Assembly.GetExecutingAssembly().GetTypes()
            .Where(x => x.IsSubclassOf(typeof(Entity))).Select(x => x.Name);

        foreach (var collection in myCollections)
        {
            if (!dbCollections.ToList().Contains(collection))
            {
                db.CreateCollection(collection);
            }
        }

    }
    public void AddData<T>(List<T> data) where T: Entity
    {
        var db = _dbConnection.GetDatabase("Showroom");
        var collection = db.GetCollection<T>(typeof(T).Name);
        collection.InsertMany(data);
    }
}