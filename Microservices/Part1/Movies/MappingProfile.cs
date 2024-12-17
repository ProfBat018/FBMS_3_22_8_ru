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
                src.adult,
                src.backdrop_path,
                src.genre_ids,
                src.id,
                src.original_language,
                src.original_title,
                src.overview,
                src.popularity,
                src.poster_path,
                src.release_date,
                src.title,
                src.video,
                src.vote_average,
                src.vote_count
            ));
    }
}