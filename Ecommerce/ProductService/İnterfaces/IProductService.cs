using ProductData.DTO;
using ProductData.Models;

namespace ProductService.İnterfaces;

public interface IProductService
{
    public Task<IEnumerable<Product>> GetAllProductsAsync();
    public Task<IEnumerable<ProductDTO>> GetAllProductsByCategoryAsync(string category);
    public Task<PaginatedList<Product>> GetAllPaginatedProductsAsync(int page, int pagesize);
    public Task<PaginatedList<Product>> GetAllPaginatedProductsByCategoryAsync(int page, int pagesize, string category);
}