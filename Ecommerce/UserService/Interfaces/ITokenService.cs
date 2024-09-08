using System.Security.Claims;
using AuthData.Models;

namespace UserService.Interfaces;




public interface ITokenService
{
    public Task<string> GenerateTokenAsync(User user);
    public Task<string> GenerateRefreshTokenAsync();
    public ClaimsPrincipal GetPrincipalFromToken(string token, bool validateLifetime = false);
    public Task<string> GenerateEmailTokenAsync(string userId);

    public Task ValidateEmailTokenAsync(string token, string userId);

}
