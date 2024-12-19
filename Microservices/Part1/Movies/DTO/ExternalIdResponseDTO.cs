namespace Movies.DTO;

public record ExternalIdResponseDTO(
    int id,
    string imdb_id,
    string wikidata_id,
    object facebook_id,
    object instagram_id,
    object twitter_id
);

