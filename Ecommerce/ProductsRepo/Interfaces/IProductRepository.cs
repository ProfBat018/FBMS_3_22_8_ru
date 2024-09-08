using System.Linq.Expressions;
using ProductData.Models;
using ProductRepo.Interfaces;

namespace ProductRepo.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    public void Update(Product product);
    public Task<Product> FindByIdAsync(int id);
}