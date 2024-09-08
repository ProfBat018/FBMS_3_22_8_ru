namespace AuthData.DTO;

public record AccessInfoDTO(
    string AccessToken,
    string RefreshToken,
    DateTime RefreshTokenExpireTime
);
