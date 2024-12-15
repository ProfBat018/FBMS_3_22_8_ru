namespace Auth.Application.DTO;


public record ResetPasswordDTO
(
    string OldPassword, 
    string NewPassword, 
    string ConfirmNewPassword 
);