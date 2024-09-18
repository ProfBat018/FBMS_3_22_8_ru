using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductData.DTO;
using ProductData.Models;
using ProductRepo.Interfaces;
using ProductService.İnterfaces;

namespace ProductService.Classes;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await _unitOfWork.ProductRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Product>> GetAllProductsByCategory(string category)
    {
        var categoryId = (await _unitOfWork.CategoryRepository.FindByNameAsync(category)).CategoryId;

        var productsCategories = await _unitOfWork.ProductCategoryRepository.GetAllAsync(c => c.CategoryId == categoryId);

        
        
    }

    public Task<IEnumerable<Product>> GetAllPaginatedProducts(int page, int pagesize)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetAllPaginatedProductsByCategory(int page, int pagesize, string category)
    {
        throw new NotImplementedException();
    }
}