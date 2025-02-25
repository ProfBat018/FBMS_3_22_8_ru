using System;
using System.Collections.Generic;

namespace ControllerFirst.Data.Models;

public class User
{
    public string UserName { get; set; } 

    public string Password { get; set; } 

    public string Email { get; set; } 

    public bool IsEmailConfirmed { get; set; }

    public Guid RefreshToken { get; set; }

    public DateTime RefreshTokenExpiration { get; set; } = DateTime.Now.AddDays(7);

    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
