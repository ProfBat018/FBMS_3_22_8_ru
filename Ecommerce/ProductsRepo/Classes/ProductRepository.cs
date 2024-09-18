using Azure.Identity;
using ProductData.Contexts;
using ProductData.Models;
using ProductRepo.Interfaces;


namespace ProductRepository.Classes;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly ProductContext _context;
    public ProductRepository(ProductContext context) : base(context)
    {
        _context = context;
    }


    public void Update(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<Product> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Product> GetProductsByRange(int categoryId)
    {
        
    }
}