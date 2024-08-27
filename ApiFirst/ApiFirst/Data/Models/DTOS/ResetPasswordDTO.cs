namespace ApiFirst.Data.Models.Requests;

public class ResetPasswordDTO
{
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
    public string ConfirmNewPassword { get; set; }
}
 