namespace Auth.Application.DTO;


public record RegisterDTO(
    string Username,
    string Email,
    string Password,
    string ConfirmPassword
);