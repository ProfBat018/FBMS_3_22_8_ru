namespace AuthData.DTO;

public record LoginResponse_DTO(string username, string role, string accessToken, string refreshToken);
