using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.DTO;
using Movies.Models;
using Movies.Services.Interfaces;

namespace Movies.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase 
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [AllowAnonymous]
    [HttpGet("{name}/{page=1}")]
    public async Task<IActionResult> GetMovies(string name, int page=1)
    {
        var res = await _movieService.GetMovies(name, page);

        if (res == null)
            throw new Exception("Failed to get movies");

        return Ok(ResponseModel<MovieResponseDTO>.SuccessResponse(res, "Movies retrieved successfully"));
    }

    [Authorize("AppUserOrAdmin")]
    [HttpPost("Save")]
    public async Task<IActionResult> SaveMovieToCollection([FromBody]MovieRequestByIdDTO requestByIdDto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var res = await _movieService.GetMovieById(requestByIdDto.id);
        if (res == null)
            throw new Exception("Failed to get movie");

        await _movieService.SaveMovieToCollectionAsync(res, userId);
        
        return Ok(ResponseModel<SearchByIdResult>.SuccessResponse(res, "Movie retrieved successfully"));
    }
    
    [Authorize("AppUserOrAdmin")]
    [HttpGet("Collection/{page=1}")]
    public async Task<IActionResult> GetCollection(int page=1)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        
        
        var res = await _movieService.GetCollectionAsync(userId, page);

        return Ok(ResponseModel<PaginatedModel<Movie>>.SuccessResponse(res, "Collection retrieved successfully"));
    }
}