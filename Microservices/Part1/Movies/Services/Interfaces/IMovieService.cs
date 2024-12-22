using Movies.DTO;
using Movies.Models;

namespace Movies.Services.Interfaces;

public interface IMovieService
{
    public Task<MovieResponseDTO> GetMovies(string name, int page=1);
    
    public Task<SearchByIdResult> GetMovieById(int id);
    
    public Task SaveMovieToCollectionAsync(SearchByIdResult movie, string userId);
    
    public Task<PaginatedModel<Movie>> GetCollectionAsync(string userId, int page=1);
}