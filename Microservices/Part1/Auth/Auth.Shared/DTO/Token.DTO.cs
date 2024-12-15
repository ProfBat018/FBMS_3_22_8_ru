namespace Auth.Application.DTO;

public record TokenDTO(
    string AccessToken,
    string RefreshToken
);