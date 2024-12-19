using System.Security.Claims;
using Auth.Application.DTO;
using Auth.Core.Interfaces;
using Auth.Core.Models;
using Auth.Infrastructure.Contexts;
using Auth.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;
using UserService.Exceptions;
using static BCrypt.Net.BCrypt;

namespace Auth.Application.Implementations;

public class AuthService : IAuthService
{
    private readonly AuthContext context;
    private readonly ITokenService tokenService;
    private readonly IBlackListService blackListService;

    public AuthService(AuthContext context, ITokenService tokenService, IBlackListService blackListService,
        IEmailSender emailSender)
    {
        this.context = context;
        this.tokenService = tokenService;
        this.blackListService = blackListService;
    }

    public async Task<AccessInfo_DTO> LoginUserAsync(LoginDTO user)
    {
        try
        {
            var foundUser = await context.Users.FirstOrDefaultAsync(u => u.Username == user.Username);

            var userRole = await context.UserRoles
                .Include(r => r.AppRole)
                .FirstOrDefaultAsync(r => r.UserId == foundUser.Id);

            if (foundUser == null)
                throw new MyAuthException(AuthErrorTypes.UserNotFound, "User not found");


            if (!Verify(user.Password, foundUser.Password))
                throw new MyAuthException(AuthErrorTypes.InvalidCredentials, "Invalid credentials");


            var tokenData = new AccessInfo_DTO(
                foundUser.Username,
                await tokenService.GenerateTokenAsync(foundUser),
                await tokenService.GenerateRefreshTokenAsync(),
                userRole.AppRole.Name,
                DateTime.Now.AddDays(1)
            );

            foundUser.RefreshToken = tokenData.refreshToken;
            foundUser.RefreshTokenExpiryTime = tokenData.refreshTokenExpireTime;

            await context.SaveChangesAsync();

            return tokenData;
        }
        catch
        {
            throw;
        }
    }

    public async Task LogOutAsync(TokenDTO userTokenInfo)
    {
        if (userTokenInfo is null)
            throw new MyAuthException(AuthErrorTypes.InvalidRequest, "Invalid client request");

        var principal = tokenService.GetPrincipalFromToken(userTokenInfo.AccessToken);

        var username = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        var user = context.Users.FirstOrDefault(u => u.Username == username);

        user.RefreshToken = null;
        user.RefreshTokenExpiryTime = DateTime.Now;
        await context.SaveChangesAsync();

        blackListService.AddTokenToBlackList(userTokenInfo.AccessToken);
    }

    public async Task<AccessInfo_DTO> RefreshTokenAsync(TokenDTO userAccessData)
    {
        if (userAccessData is null)
            throw new MyAuthException(AuthErrorTypes.InvalidRequest, "Invalid client request");

        var accessToken = userAccessData.AccessToken;
        var refreshToken = userAccessData.RefreshToken;

        var principal = tokenService.GetPrincipalFromToken(accessToken);

        var username = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        var user = context.Users.FirstOrDefault(u => u.Username == username);

        var userRole = await context.UserRoles
            .Include(r => r.AppRole)
            .FirstOrDefaultAsync(r => r.UserId == user.Id);

        if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            throw new MyAuthException(AuthErrorTypes.InvalidRequest, "Invalid client request");

        var newAccessToken = await tokenService.GenerateTokenAsync(user);
        var newRefreshToken = await tokenService.GenerateRefreshTokenAsync();

        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(1);

        await context.SaveChangesAsync();


        return new AccessInfo_DTO(
            username,
            newAccessToken,
            newRefreshToken,
            userRole.AppRole.Name,
            user.RefreshTokenExpiryTime);
    }

    public async Task<User> RegisterUserAsync(RegisterDTO user)
    {
        try
        {
            var newUser = new User
            {
                Username = user.Username,
                Email = user.Email,
                Password = HashPassword(user.Password)
            };


            var appRoles = AppRoles.Roles;
            var rolesInDb = await context.AppRoles.ToListAsync();


            foreach (var item in appRoles)
            {
                if (rolesInDb.All(x => x.Name != item))
                {
                    await context.AppRoles.AddAsync(new AppRole { Name = item });
                }
            }


            await context.SaveChangesAsync();

            var role = context.AppRoles.FirstOrDefault(r => r.Name == "AppUser");

            var roleToApply = new UserRole()
            {
                RoleId = role.Id,
                UserId = newUser.Id
            };

            await context.Users.AddAsync(newUser);
            await context.UserRoles.AddAsync(roleToApply);
            await context.SaveChangesAsync();

            return newUser;
        }
        catch
        {
            throw;
        }
    }
}