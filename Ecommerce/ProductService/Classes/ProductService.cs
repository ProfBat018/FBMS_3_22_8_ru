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

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _unitOfWork.ProductRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Product>> GetAllProductsByCategoryAsync(string category)
    {
        var categoryId = (await _unitOfWork.CategoryRepository.FindByNameAsync(category)).CategoryId;

        var productsCategories = await _unitOfWork.ProductCategoryRepository.GetAllAsync(c => c.CategoryId == categoryId);

        var productIds = productsCategories.Select(pc => pc.ProductId).Distinct().ToList();

        var products = await _unitOfWork.ProductRepository.GetAllAsync(p => productIds.Contains(p.ProductId));

        return products;
    }

    public async Task<PaginatedList<Product>> GetAllPaginatedProductsAsync(int page, int pagesize)
    {
        return await _unitOfWork.ProductRepository.GetAllPaginatedAsync(page, pagesize);
    }

    public Task<PaginatedList<Product>> GetAllPaginatedProductsByCategoryAsync(int page, int pagesize, string category)
    {
        throw new NotImplementedException();

    }
}