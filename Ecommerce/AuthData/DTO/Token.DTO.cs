namespace AuthData.DTO;

public record TokenDTO(
    string AccessToken,
    string RefreshToken
);