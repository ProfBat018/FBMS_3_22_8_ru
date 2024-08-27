using System.Text.Json.Serialization;

namespace CinemaRazor.Data.Models;

public class MovieSearchResult
{
    [JsonPropertyName("page")] public int Page { get; set; }

    [JsonPropertyName("results")] public MovieInfo[] Movies { get; set; }

    [JsonPropertyName("total_pages")] public int TotalPages { get; set; }

    [JsonPropertyName("total_results")] public int TotalResults { get; set; }
}

public class MovieInfo
{
    [JsonPropertyName("adult")] public bool Adult { get; set; }

    [JsonPropertyName("backdrop_path")] public string BackdropPath { get; set; }

    [JsonPropertyName("genre_ids")] public int[] GenreIds { get; set; }

    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("original_language")]
    public string OriginalLanguage { get; set; }

    [JsonPropertyName("original_title")] public string OriginalTitle { get; set; }

    [JsonPropertyName("overview")] public string Overview { get; set; }

    [JsonPropertyName("popularity")] public double Popularity { get; set; }

    [JsonPropertyName("poster_path")] public string PosterPath { get; set; }

    [JsonPropertyName("release_date")] public string ReleaseDate { get; set; }

    [JsonPropertyName("title")] public string Title { get; set; }

    [JsonPropertyName("video")] public bool Video { get; set; }

    [JsonPropertyName("vote_average")] public double VoteAverage { get; set; }

    [JsonPropertyName("vote_count")] public int VoteCount { get; set; }
}