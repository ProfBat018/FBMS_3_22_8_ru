using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductData.DTO;
using ProductRepo.Interfaces;
using ProductService.İnterfaces;

namespace ProductApiService.Controllers;

[Authorize(Policy = "AdminPolicy")]
[Route("api/admin/products")]
[ApiController]
public class AdminProductsController : ControllerBase
{
    private readonly IProductService _productService;
    public AdminProductsController( IProductService productService)
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

    [HttpPost("add")]
    public async Task<IActionResult> AddNewProductAsync([FromBody] AddProductDTO productDto, CancellationToken cancellationToken)
    {
        var res = await _productService.AddNewProductAsync(productDto, cancellationToken);

        return Ok(res);
    }

    [HttpPost("image/add")]
    public async Task<IActionResult> UploadImageAsync([FromForm] IFormFile file, CancellationToken cancellationToken)
    {
        var res = await _productService.UploadImageAsync(file, cancellationToken);
    
        return Ok(res);
    }

}