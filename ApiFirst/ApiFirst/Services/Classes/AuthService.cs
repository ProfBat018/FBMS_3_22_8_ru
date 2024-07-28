using ApiFirst.Data.Contexts;
using ApiFirst.Data.Models;
using ApiFirst.Exceptions;
using ApiFirst.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static BCrypt.Net.BCrypt;

namespace ApiFirst.Services.Classes;

public class AuthService : IAuthService
{
    private readonly AuthContext context;
    private readonly ITokenService tokenService;
    public AuthService(AuthContext context, ITokenService tokenService)
    {
        this.context = context;
        this.tokenService = tokenService;
    }

    public async Task<TokenData> LoginUserAsync(LoginUser user)
    {
        try
        {
            var foundUser = await context.Users.FirstOrDefaultAsync(u => u.Username == user.Username);

            if (foundUser == null)
            {
                throw new MyAuthException(AuthErrorTypes.UserNotFound, "User not found");
            }

            if (!Verify(user.Password, foundUser.Password))
            {
                throw new MyAuthException(AuthErrorTypes.InvalidCredentials, "Invalid password");
            }

            var tokenData = new TokenData()
            {
                AccessToken = await tokenService.GenerateTokenAsync(foundUser),
                RefreshToken = await tokenService.GenerateRefreshTokenAsync(),
                RefreshTokenExpireTime = DateTime.Now.AddDays(1)
            };

            foundUser.RefreshToken = tokenData.RefreshToken;
            foundUser.RefreshTokenExpiryTime = tokenData.RefreshTokenExpireTime;

            await context.SaveChangesAsync();

            return tokenData;
        }
        catch
        {
            throw;
        }
    }

    public async Task<TokenData> RefreshTokenAsync(RefreshUser userAccessData)
    {
        if (userAccessData is null)
            throw new MyAuthException(AuthErrorTypes.InvalidRequest, "Invalid client request");

        var accessToken = userAccessData.AccessToken;
        var refreshToken = userAccessData.RefreshToken;

        var principal = tokenService.GetPrincipalFromExpiredToken(accessToken);

        var username = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        var user = context.Users.FirstOrDefault(u => u.Username == username);

        if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            throw new MyAuthException(AuthErrorTypes.InvalidRequest, "Invalid client request");

        var newAccessToken = await tokenService.GenerateTokenAsync(user);
        var newRefreshToken = await tokenService.GenerateRefreshTokenAsync();

        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(35);

        await context.SaveChangesAsync();

        return new TokenData
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken,
            RefreshTokenExpireTime = user.RefreshTokenExpiryTime
        };
    }

    public async Task<User> RegisterUserAsync(RegisterUser user)
    {
        try
        {
            var newUser = new User
            {
                Username = user.Username,
                Email = user.Email,
                Password = HashPassword(user.Password)
            };

            await context.AddAsync(newUser);
            await context.SaveChangesAsync();

            return newUser;
        }
        catch
        {
            throw;
        }
    }
}
