using Back;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(ops => ops.AddDefaultPolicy(policy =>
{
    policy.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
}));

builder.Services.AddDbContext<BackContext>(ops => ops.UseSqlServer(
    builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

app.UseCors();

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

 List<Forecast> forecasts = new();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapPost("/saveData", async (BackContext context) =>
{
    await context.Forecasts.AddRangeAsync(forecasts);
    await context.SaveChangesAsync();
});
app.MapGet("/weatherforecast", () =>
    {
        forecasts = Enumerable.Range(1, 5).Select(index =>
            new Forecast(
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)).ToShortDateString(),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            )).ToList();
        return forecasts;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();


app.MapGet("/getallfromdb", async (BackContext context) =>
{
    return await context.Forecasts.ToListAsync();
});
app.Run();

