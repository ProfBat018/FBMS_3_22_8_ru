using Movies.Contexts;
using Movies.Models;

namespace Movies;
using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<SearchByNameResult, Movie>()
            .ConstructUsing(src => new Movie(
                src.Adult,
                src.BackdropPath,
                src.GenreIds,
                src.Id,
                src.OriginalLanguage,
                src.OriginalTitle,
                src.Overview,
                src.Popularity,
                src.PosterPath,
                src.ReleaseDate,
                src.Title,
                src.Video,
                src.VoteAverage,
                src.VoteCount
            ));
    }
}