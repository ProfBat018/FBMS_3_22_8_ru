using System.ComponentModel.DataAnnotations;

namespace Auth.Models.Form;

public class LoginModel
{
    [RegularExpression("(^[a-zA-Z0-9._-]+)(@[a-zA-Z0-9.-]+)(\\.[a-zA-Z]{2,4})$")]
    public string Email { get; set; }
    public string Password { get; set; }
}