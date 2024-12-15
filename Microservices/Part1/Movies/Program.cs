using Microsoft.EntityFrameworkCore;
using Movies;
using Movies.Contexts;
using Movies.Services.Classes;
using Movies.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddDbContext<MovieContext>(ops => ops.UseSqlServer(
    builder.Configuration.GetConnectionString("Movies")));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IMovieService, MovieService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

