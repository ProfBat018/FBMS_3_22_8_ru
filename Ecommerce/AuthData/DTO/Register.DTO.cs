namespace AuthData.DTO;

public record RegisterDTO(
    string Username,
    string Email,
    string Password,
    string ConfirmPassword
);