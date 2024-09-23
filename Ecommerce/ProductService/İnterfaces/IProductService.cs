using Microsoft.AspNetCore.Http;
using ProductData.DTO;
using ProductData.Models;

namespace ProductService.İnterfaces;

public interface IProductService
{
    public Task<PaginatedList<ProductDTO>> GetAllPaginatedProductsAsync(int page, int pagesize);
    public Task<PaginatedList<ProductDTO>> GetAllPaginatedProductsByCategoryAsync(int page, int pagesize, int categoryId);
    public Task<PostResponse> AddNewProductAsync(AddProductDTO newProduct, CancellationToken cancellationToken);
    public Task<PostResponse> UploadImageAsync(IFormFile file, CancellationToken cancellationToken);

}