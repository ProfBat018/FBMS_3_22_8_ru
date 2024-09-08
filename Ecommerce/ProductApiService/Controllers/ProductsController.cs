using Microsoft.AspNetCore.Mvc;
using ProductRepo.Interfaces;

namespace ProductApiService.Controllers;

[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet("Products/All")]
    public async Task<IActionResult> GetAllProductsAsync()
    {
        return Ok(await _unitOfWork.ProductRepository.GetAllAsync());
    }
    
    
    [HttpGet("Products/{page}/{pagesize}")]
    public async Task<IActionResult> GetAllPaginatedProductsAsync(int page,int pagesize)
    {
        return Ok(await _unitOfWork.ProductRepository.GetAllPaginatedAsync(page, pagesize));
    }
    
}