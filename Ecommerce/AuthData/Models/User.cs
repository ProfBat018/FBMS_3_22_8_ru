using System.Security.Claims;
using System.Security.Principal;

namespace AuthData.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsEmailConfirmed { get; set; } = false;
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }
}
