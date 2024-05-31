using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using TestApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(x => x.AddPolicy("CorsPolicy",
    policyBuilder => { policyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("getcars", async () =>
{
    var fs = new FileStream("sample.json", FileMode.OpenOrCreate);

    var res = await JsonSerializer.DeserializeAsync<CarsData>(fs);

    try
    {
        return res.Data;
    }
    catch (Exception e)
    {
        throw e;
    }

}).WithName("GetCars").WithOpenApi();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");


app.Run();