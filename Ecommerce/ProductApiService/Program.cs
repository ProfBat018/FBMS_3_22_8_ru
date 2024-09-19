using Microsoft.EntityFrameworkCore;
using ProductData.Contexts;
using ProductRepo.Interfaces;
using ProductRepository.Classes;
using ProductService.Classes;
using ProductService.İnterfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddDbContext<ProductContext>(ops => 
    ops.UseSqlServer(builder.Configuration.GetConnectionString("StepEcommerce16")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductService, ProductService.Classes.ProductService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.MapControllers();

app.UseHttpsRedirection();

app.Run();

