namespace Movies.Models;

public class Movie
{
    public Movie()
    {
        
    }
    public Movie(bool adult, string backdropPath, int[] genreIds, int id, string originalLanguage, string originalTitle, string overview, double popularity, string posterPath, string releaseDate, string title, bool video, double voteAverage, int voteCount)
    {
        Adult = adult;
        BackdropPath = backdropPath;
        GenreIds = genreIds;
        Id = id;
        OriginalLanguage = originalLanguage;
        OriginalTitle = originalTitle;
        Overview = overview;
        Popularity = popularity;
        PosterPath = posterPath;
        ReleaseDate = releaseDate;
        Title = title;
        Video = video;
        VoteAverage = voteAverage;
        VoteCount = voteCount;
    }

    public bool Adult { get; set; }
    public string BackdropPath { get; set; }
    public int[] GenreIds { get; set; }
    public int Id { get; set; }
    public string OriginalLanguage { get; set; }
    public string OriginalTitle { get; set; }
    public string Overview { get; set; }
    public double Popularity { get; set; }
    public string PosterPath { get; set; }
    public string ReleaseDate { get; set; }
    public string Title { get; set; }
    public bool Video { get; set; }
    public double VoteAverage { get; set; }
    public int VoteCount { get; set; }
}