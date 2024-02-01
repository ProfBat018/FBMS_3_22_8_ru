using LINQ1.Services;
using Microsoft.Extensions.Configuration;
using TechDataLayer;

IConfigurationBuilder builder = new ConfigurationBuilder();
IDataConnectionService dataConnectionService = new DataConnectionService(builder);

var options = dataConnectionService.Configure<TechCommerceDbContext>("Default");

using var dbContext = new TechCommerceDbContext(options);

var categories = dbContext.Categories;

foreach (var item in categories)
{
    Console.WriteLine(item.Name);
}



