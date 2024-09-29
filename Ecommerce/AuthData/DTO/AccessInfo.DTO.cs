namespace AuthData.DTO;

public record AccessInfo_DTO(
    string userName,
    string accessToken,
    string refreshToken,
    string role,
    DateTime refreshTokenExpireTime
);
