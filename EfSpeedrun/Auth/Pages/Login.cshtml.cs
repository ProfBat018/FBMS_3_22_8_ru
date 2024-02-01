using Microsoft.AspNetCore.Mvc.RazorPages;
using static BCrypt.Net.BCrypt;
namespace Auth.Pages;

public class Login : PageModel
{
    public void OnGet()
    {
        
    }

    public void OnPost(string email, string password)
    {
    }
}