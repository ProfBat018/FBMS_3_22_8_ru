using Microsoft.AspNetCore.Mvc;
using ProductRepo.Interfaces;
using ProductService.İnterfaces;

namespace ProductApiService.Controllers;

[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController( IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("Products/All")]
    public async Task<IActionResult> GetAllProductsAsync()
    {
        return Ok(await _productService.GetAllProductsAsync());
    }

    [HttpGet("Products/All/{category}")]
    public async Task<IActionResult> GetAllProductsAsync(string category)
    {
        return Ok(await _productService.GetAllProductsByCategoryAsync(category));
    }


    [HttpGet("Products/{page}/{pagesize}")]
    public async Task<IActionResult> GetAllPaginatedProductsAsync(int page,int pagesize)
    {
        return Ok(await _productService.GetAllPaginatedProductsAsync(page, pagesize));
    }
    
    [HttpGet("Products/{categoryName}/{page}/{pagesize}")]
    public async Task<IActionResult> GetAllPaginatedProductsAsync(int page,int pagesize, string categoryName)
    {

        return Ok(_productService.GetAllPaginatedProductsByCategoryAsync(page, pagesize, categoryName));
    }
}