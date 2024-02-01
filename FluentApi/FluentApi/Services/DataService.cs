using FluentApi.Data.Contexts;

namespace FluentApi.Services;

public class DataService
{
    private readonly TechCommerceDbContext _context;

    public DataService(TechCommerceDbContext context)
    {
        _context = context;
    }
    
    public void GetAllProducts()
    {
        var products = _context.Products.ToList();
        
        foreach (var product in products)
        {
            Console.WriteLine(product.Name);
        }
    }
}