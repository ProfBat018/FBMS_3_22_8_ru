using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductData.Configs;
using ProductData.DTO;
using ProductData.Models;
using ProductRepo.Interfaces;


namespace ProductsApiService.Controllers;



[Route("api/admin/categories")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Mapper _mapper;

    public CategoryController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _mapper = MappingConfiguration.InitializeConfig();
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllCategoriesAsync()
    {
        var res = await _unitOfWork.CategoryRepository.GetAllAsync();

        var mappingRes = _mapper.Map<IEnumerable<CategoryDTO>>(res);

        return Ok(mappingRes);
    }
}