using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("/app/ocelot.json", optional: true, reloadOnChange: true);

builder.Services.AddOcelot();

var app = builder.Build();

app.UseOcelot().Wait();

//app.UseHttpsRedirection();

app.Run();


