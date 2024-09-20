using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductData.Configs;
using ProductData.Contexts;
using ProductData.DTO;
using ProductData.Models;
using ProductRepo.Interfaces;
using ProductService.İnterfaces;
using System.Linq;

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


    public async Task<PaginatedList<ProductDTO>> GetAllPaginatedProductsAsync(int page, int pagesize)
    {
        var res =  await _unitOfWork.ProductRepository.GetAllPaginatedAsync(page, pagesize);

        var items = _mapper.Map<IEnumerable<ProductDTO>>(res.Items);

        return new PaginatedList<ProductDTO>(items, res.TotalCount, page, pagesize);
    }

    public async Task<PaginatedList<ProductDTO>> GetAllPaginatedProductsByCategoryAsync(int page, int pagesize, int categoryId)
    {
        var productsCategories =
              await _unitOfWork.ProductCategoryRepository.GetAllAsync(c => c.CategoryId == categoryId);

        var productIds = productsCategories.Select(pc => pc.ProductId).Distinct().ToList();
        
        var res = await _unitOfWork.ProductRepository.GetAllPaginatedAsync(page, pagesize, p => productIds.Contains(p.ProductId));


        var items = _mapper.Map<IEnumerable<ProductDTO>>(res.Items);

        return new PaginatedList<ProductDTO>(items, res.PageNumber, res.PageSize, res.TotalCount);
    }
}