using System.ComponentModel.DataAnnotations;

namespace Auth.Models;

public class User(string email, string password)
{
    public string Id = Guid.NewGuid().ToString();
    public string Email = email;
    public string Password = password;
};