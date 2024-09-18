using ProductData.DTO;
using ProductData.Models;

namespace ProductService.İnterfaces;

public interface IProductService
{
    public Task<IEnumerable<Product>> GetAllProducts();
    public Task<IEnumerable<Product>> GetAllProductsByCategory(string category);
    public Task<IEnumerable<Product>> GetAllPaginatedProducts(int page, int pagesize);
    public Task<IEnumerable<Product>> GetAllPaginatedProductsByCategory(int page, int pagesize, string category);
}