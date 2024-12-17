using System.Text.Json;
using Movies.Contexts;
using Movies.Services.Interfaces;
using RestSharp;

namespace Movies.Services.Classes;

public class MovieService : IMovieService
{
    private readonly MovieContext _movieContext;
    
    
    public MovieService(MovieContext movieContext)
    {
        _movieContext = movieContext;
    }
    
    public async Task<MovieResponseDTO> GetMovies(string name, int page=1)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException("Name cannot be null or empty");
        }

        if (page <= 0)
        {
            page = 1;
        }
        
        var options = new RestClientOptions($"https://api.themoviedb.org/3/search/movie?query=batman&include_adult=false&language=en-US&page={page}");
        var client = new RestClient(options);
        var request = new RestRequest("");
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIyYTcxYWMxNTc3NzdkZTM3YzIxNTFjY2Q3OTQxZjU1YSIsIm5iZiI6MTY5Nzc4NDY2OS4yMDgsInN1YiI6IjY1MzIyMzVkOWFjNTM1MDg3NzU2MGEzYyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.hFRAfYIZ3c589bcPOw8gDGN_fPWT1BZnimjUxlbYa3I");
       
        var response = await client.GetAsync(request);

        if (!response.IsSuccessful)
        {
            throw new Exception("Failed to get movies");
        }
        
        using var memoryStream = new MemoryStream();
        using var writer = new StreamWriter(memoryStream);
        
        await writer.WriteAsync(response.Content);
        await writer.FlushAsync();
        memoryStream.Position = 0;
        
        return await JsonSerializer.DeserializeAsync<MovieResponseDTO>(memoryStream);
    }
}
