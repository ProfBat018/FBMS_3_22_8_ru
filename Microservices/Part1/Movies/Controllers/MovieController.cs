using Microsoft.AspNetCore.Mvc;
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
    
    [HttpGet("Movie/{name}/{page=1}")]
    public async Task<IActionResult> GetMovies(string name, int page=1)
    {
        var res = await _movieService.GetMovies(name, page);

        if (res == null)
            throw new Exception("Failed to get movies");

        return Ok(ResponseModel<MovieResponseDTO>.SuccessResponse(res, "Movies retrieved successfully"));

    }
}