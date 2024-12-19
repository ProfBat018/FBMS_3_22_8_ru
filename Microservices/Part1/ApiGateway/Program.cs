using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);


builder.Services.AddAuthorization();
builder.Services.AddOcelot();

var app = builder.Build();


app.UseOcelot().Wait();

app.UseHttpsRedirection();

app.Run();


