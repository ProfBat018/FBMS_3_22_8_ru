public record MovieResponseDTO(
    int Page,
    SearchByNameResult[] Results,
    int TotalPages,
    int TotalResults
);

public record SearchByNameResult(
    bool Adult,
    string BackdropPath,
    int[] GenreIds,
    int Id,
    string OriginalLanguage,
    string OriginalTitle,
    string Overview,
    double Popularity,
    string PosterPath,
    string ReleaseDate,
    string Title,
    bool Video,
    double VoteAverage,
    int VoteCount
);