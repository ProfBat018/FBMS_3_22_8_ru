using Auth.Contexts;
using Auth.Models;
using Auth.Models.Form;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Services.Classes;

public class RegisterService : IRegisterService
{
    public void Register(RegisterModel model)
    {
        using UserContext context = new();

        var userToAdd = new User(model.Email, model.Password);
        
        context.Users.Add(userToAdd);
        context.SaveChanges();
    }
}