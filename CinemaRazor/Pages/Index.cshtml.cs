using System.Text.Json;
using CinemaRazor.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaRazor.Pages;

public class IndexModel : PageModel
{

    public MovieSearchResult SearchResult { get; set; } = new();

    private async Task<MovieSearchResult> GetMovies(string page, string title)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri =
                new Uri(
                    $"https://api.themoviedb.org/3/search/movie?query={title}&include_adult=false&language=en-US&page={page}"),
            Headers =
            {
                { "accept", "application/json" },
                {
                    "Authorization",
                    "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIyYTcxYWMxNTc3NzdkZTM3YzIxNTFjY2Q3OTQxZjU1YSIsIm5iZiI6MTcyNDIxODA4Ni43NzE5MjEsInN1YiI6IjY1MzIyMzVkOWFjNTM1MDg3NzU2MGEzYyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.c3P9euErErKtpw1azLHd2K7zS-0pqd_mn_GRDfDp-Tw"
                },
            },
        };
        using var response = await client.SendAsync(request);

        response.EnsureSuccessStatusCode();
        
        var jsonStream = await response.Content.ReadAsStreamAsync();

        return  await JsonSerializer.DeserializeAsync<MovieSearchResult>(jsonStream);
    }

    public IndexModel()
    {
    }

    public void OnGet()
    {
    }

    public async Task OnPostTitle(string title)
    {
        TempData["MovieTitle"] = title;

        SearchResult = await GetMovies("1", title);
    }
    
    public async Task OnPostPage(string currentPage)
    {
        string title = TempData["MovieTitle"].ToString();
        SearchResult = await GetMovies(currentPage, title);
    }
}

public class SearchInput
{
    public string Title { get; set; }
}