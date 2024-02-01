using System.ComponentModel.DataAnnotations;

namespace Auth.Models.Form;

public class RegisterModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}