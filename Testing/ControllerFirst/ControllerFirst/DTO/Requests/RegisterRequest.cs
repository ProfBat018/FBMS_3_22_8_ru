namespace ControllerFirst.DTO.Requests;

public record RegisterRequest
(string Username, string Password, string ConfirmPassword, string Email);


