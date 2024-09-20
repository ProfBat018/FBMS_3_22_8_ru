using ProductData.DTO;
using ProductData.Models;

namespace ProductService.İnterfaces;

public interface IProductService
{
    public Task<PaginatedList<ProductDTO>> GetAllPaginatedProductsAsync(int page, int pagesize);
    public Task<PaginatedList<ProductDTO>> GetAllPaginatedProductsByCategoryAsync(int page, int pagesize, int categoryId);
}