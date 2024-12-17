

using System.Security.Claims;
using Auth.Core.Models;

namespace Auth.Core.Interfaces;

public interface ITokenService
{
    public Task<string> GenerateTokenAsync(User user);
    public Task<string> GenerateRefreshTokenAsync();
    public ClaimsPrincipal GetPrincipalFromToken(string token, bool validateLifetime = false);
    public Task<string> GenerateEmailTokenAsync(string userId);
    public Task<string> ValidateEmailTokenAsync(string token);


}
