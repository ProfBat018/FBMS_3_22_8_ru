using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductData.DTO;
using ProductRepo.Interfaces;
using ProductService.İnterfaces;

namespace ProductApiService.Controllers;

[Route("api/user/products")]
[ApiController]
public class UserProductsController : ControllerBase
{
    private readonly IProductService _productService;
    public UserProductsController( IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("all/{page}/{pagesize}")]
    public async Task<IActionResult> GetAllProductsAsync(int page, int pagesize)
    {
        return Ok(await _productService.GetAllPaginatedProductsAsync(page, pagesize));
    }

    [HttpGet("all/{categoryId}/{page}/{pagesize}")]
    public async Task<IActionResult> GetAllPaginatedProductsAsync(int page,int pagesize, int categoryId)
    {

        return Ok(await _productService.GetAllPaginatedProductsByCategoryAsync(page, pagesize, categoryId));
    }
}   