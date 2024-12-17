public record MovieResponseDTO(
    int page,
    SearchByNameResult[] results,
    int total_pages,
    int total_results
);

public record SearchByNameResult(
    bool adult,
    string backdrop_path,
    int[] genre_ids,
    int id,
    string original_language,
    string original_title,
    string overview,
    double popularity,
    string poster_path,
    string release_date,
    string title,
    bool video,
    double vote_average,
    int vote_count
);