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
    
    [HttpGet("Movie/{name}")]
    public async Task<IActionResult> GetMovies(string name)
    {
        

        return Ok("Movies");
    }
}