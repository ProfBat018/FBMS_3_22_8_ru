namespace Auth.Application.DTO;

public record AccessInfo_DTO(
    string userName,
    string accessToken,
    string refreshToken,
    string csrfToken,
    string role,
    DateTime refreshTokenExpireTime
);
