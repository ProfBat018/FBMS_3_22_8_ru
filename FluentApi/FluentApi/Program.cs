using FluentApi.Data.Contexts;
using FluentApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleInjector;

var configBuilder = new ConfigurationBuilder();

configBuilder.AddJsonFile("appsettings.json");

var config = configBuilder.Build();

var connectionString = config.GetConnectionString("DefaultConnection");

var optionsBuilder = new DbContextOptionsBuilder<TechCommerceDbContext>();

optionsBuilder.UseSqlServer(connectionString);

var ops = optionsBuilder.Options;

var container = new Container();

container.RegisterSingleton<TechCommerceDbContext>(() => new TechCommerceDbContext(optionsBuilder.Options));

container.Register<DataService>();

container.Verify();

var service = container.GetInstance<DataService>();

service.GetAllProducts();



