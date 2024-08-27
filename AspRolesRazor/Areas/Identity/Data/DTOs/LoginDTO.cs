#nullable disable
using System.ComponentModel.DataAnnotations;


namespace AspRolesRazor.Areas.Data.DTOs;
public class LoginDTO
{
          
    [Required]
    [EmailAddress]
    public string Email { get; set; }

         
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

          
    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
}