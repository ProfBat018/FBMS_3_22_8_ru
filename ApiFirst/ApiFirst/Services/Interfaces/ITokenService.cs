using ApiFirst.Data.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Primitives;
using System.Security.Claims;

namespace ApiFirst.Services.Interfaces;

public interface ITokenService
{
    public Task<string> GenerateTokenAsync(User user);
    public Task<string> GenerateRefreshTokenAsync();
    public ClaimsPrincipal GetPrincipalFromToken(string token, bool validateLifetime = false);
    public Task<string> GenerateEmailTokenAsync(string userId);

    public Task ValidateEmailTokenAsync(string token);

}
