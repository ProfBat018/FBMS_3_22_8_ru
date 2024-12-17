namespace Auth.Application.DTO;


public record Refresh_DTO(
    string accessToken,
    string refreshToken);