using ProductData.DTO;
using ProductData.Models;

namespace ProductService.İnterfaces;

public interface IProductService
{
    public Task<IEnumerable<Product>> GetAllProductsAsync();
    public Task<IEnumerable<ProductDTO>> GetAllProductsByCategoryAsync(int categoryId);
    public Task<PaginatedList<ProductDTO>> GetAllPaginatedProductsAsync(int page, int pagesize);
    public Task<PaginatedList<ProductDTO>> GetAllPaginatedProductsByCategoryAsync(int page, int pagesize, int categoryId);
}