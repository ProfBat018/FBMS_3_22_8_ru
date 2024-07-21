using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MinimalFirst;
using MinimalFirst.Data;
using MinimalFirst.Data.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShowroomDbContext>(ops => ops.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapGet("/getcars", async (ShowroomDbContext db) =>
{
    return await db.Cars.ToListAsync();
})
.WithOpenApi()
.WithName("GetCars")
.WithDescription("Get all cars from database asynchronously");

app.MapGet("/getcar/{id}", async (ShowroomDbContext db, int id) =>
{
    return await db.Cars.FindAsync(id);
})
    .WithOpenApi()
    .WithName("GetCarById")
    .WithDescription("Get a car by its ID");


app.MapPost("/addcar", async (ShowroomDbContext db, Car car) =>
{
    db.Cars.Add(car);
    await db.SaveChangesAsync();
    return Results.Created($"/getcars", car);
})
    .WithOpenApi()
    .WithName("AddCar");



app.Run();




