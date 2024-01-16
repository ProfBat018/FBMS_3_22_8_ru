using System;
using DbFirst;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


DbContextOptions<AcademyContext> ConfigStartup(string connectionName)
{
    ConfigurationBuilder builder = new();
    builder.AddJsonFile("appsettings.json");

    var config = builder.Build();

    string? connectionString = config.GetConnectionString(connectionName);

    var optionsBuilder = new DbContextOptionsBuilder<AcademyContext>();

    DbContextOptions<AcademyContext>? options = optionsBuilder
        .UseSqlServer(connectionString).Options;

    return options ?? throw new NullReferenceException();
}

using AcademyContext academyContext = new(ConfigStartup("Default"));

var res = academyContext.People.Where(x => x.Id > 5);

foreach (var item in res)
{
    Console.WriteLine(item.Name);   
}



