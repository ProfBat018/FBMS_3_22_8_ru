#nullable disable
using System.ComponentModel.DataAnnotations;

namespace AspRolesRazor.Areas.Data.DTOs;
public class ResendConfirmationDTO
{
      
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}