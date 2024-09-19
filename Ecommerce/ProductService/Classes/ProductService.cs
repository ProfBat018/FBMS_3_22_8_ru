using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductData.Configs;
using ProductData.DTO;
using ProductData.Models;
using ProductRepo.Interfaces;
using ProductService.İnterfaces;

namespace ProductService.Classes;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Mapper _mapper;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _mapper = MappingConfiguration.InitializeConfig();
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _unitOfWork.ProductRepository.GetAllAsync();
    }

    public async Task<IEnumerable<ProductDTO>> GetAllProductsByCategoryAsync(int categoryId)
    {
        var productsCategories =
            await _unitOfWork.ProductCategoryRepository.GetAllAsync(c => c.CategoryId == categoryId);

        var productIds = productsCategories.Select(pc => pc.ProductId).Distinct().ToList();

        var products = await _unitOfWork.ProductRepository.GetAllAsync(p => productIds.Contains(p.ProductId));

        var res =  _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
        
        return res;
    }

    public async Task<PaginatedList<ProductDTO>> GetAllPaginatedProductsAsync(int page, int pagesize)
    {
        var res =  await _unitOfWork.ProductRepository.GetAllPaginatedAsync(page, pagesize);

        var items = _mapper.Map<IEnumerable<ProductDTO>>(res.Items);

        return new PaginatedList<ProductDTO>(items, res.PageNumber, res.PageSize, res.TotalCount);
    }

    public Task<PaginatedList<ProductDTO>> GetAllPaginatedProductsByCategoryAsync(int page, int pagesize, int categoryId)
    {
        throw new NotImplementedException();
    }
}