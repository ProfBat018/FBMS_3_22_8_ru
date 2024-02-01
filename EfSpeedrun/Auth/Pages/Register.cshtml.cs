using Auth.Contexts;
using Auth.Models;
using Auth.Models.Form;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static BCrypt.Net.BCrypt;

namespace Auth.Pages;

public class Register : PageModel
{
    public RegisterModel? RegisterModel { get; set; }
    private readonly UserContext _context;

    public Register(UserContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
    }

    public void OnPost(string email, string password, string confirmPassword)
    {
        if (password != confirmPassword)
        {
            throw new Exception("Passwords do not match");
        }

        RegisterModel = new()
        {
            Email = email,
            Password = password,
            ConfirmPassword = confirmPassword
        };
        
        var userToAdd = new User(email, HashPassword(password));

        _context.Users.Add(userToAdd);

        _context.SaveChanges();
    }
}