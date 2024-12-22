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


        CreateMap<SearchByIdResult, Movie>()
            .ConstructUsing(src => new Movie(false, src.movie_results[0].backdrop_path, src.movie_results[0].genre_ids,
                src.movie_results[0].id, src.movie_results[0].original_language, src.movie_results[0].original_title,
                src.movie_results[0].overview, src.movie_results[0].popularity, src.movie_results[0].poster_path,
                src.movie_results[0].release_date, src.movie_results[0].title, src.movie_results[0].video,
                src.movie_results[0].vote_average, src.movie_results[0].vote_count));
    }
}