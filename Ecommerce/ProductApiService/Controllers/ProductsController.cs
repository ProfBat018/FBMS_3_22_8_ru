using Microsoft.AspNetCore.Mvc;
using ProductData.DTO;
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

    [HttpGet("Products/All/{page}/{pagesize}")]
    public async Task<IActionResult> GetAllProductsAsync(int page, int pagesize)
    {
        return Ok(await _productService.GetAllPaginatedProductsAsync(page, pagesize));
    }

    [HttpGet("Products/{categoryId}/{page}/{pagesize}")]
    public async Task<IActionResult> GetAllPaginatedProductsAsync(int page,int pagesize, int categoryId)
    {

        return Ok(await _productService.GetAllPaginatedProductsByCategoryAsync(page, pagesize, categoryId));
    }

    [HttpPost("Product/Add")]
    public async Task<IActionResult> AddNewProductAsync([FromBody] AddProductDTO productDto, CancellationToken cancellationToken)
    {
        var res = await _productService.AddNewProductAsync(productDto, cancellationToken);

        return Ok(res);
    }

    [HttpPost("Image/Add")]
    public async Task<IActionResult> UploadImageAsync([FromForm] IFormFile file, CancellationToken cancellationToken)
    {
        var res = await _productService.UploadImageAsync(file, cancellationToken);
    
        return Ok(res);
    }

}