using CinemaMinus.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CinemaMinus.Services.Classes;

 class DownloadService : IDownloadService
{
    public  string DownloadData(string movieName, string page)
    {
        var client = new HttpClient();

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://api.themoviedb.org/3/search/movie?query={movieName}&include_adult=false&language=en-US&page={page}"),
            Headers =
            {
                { "accept", "application/json" },
                { "Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIyYTcxYWMxNTc3NzdkZTM3YzIxNTFjY2Q3OTQxZjU1YSIsInN1YiI6IjY1MzIyMzVkOWFjNTM1MDg3NzU2MGEzYyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.qommZjydCjfhkiu6d4egV1K45qpY32pBkShbKJixZto" },
            },
        };

        using var response = client.Send(request);

        response.EnsureSuccessStatusCode();

        var stream = response.Content.ReadAsStream();

        using StreamReader sr = new(stream);

        return sr.ReadToEnd() ?? throw new NullReferenceException("Data is not found");
    }
}
