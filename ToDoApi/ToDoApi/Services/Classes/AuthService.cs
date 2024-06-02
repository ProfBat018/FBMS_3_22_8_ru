using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ToDoApi.Models;
using ToDoApi.Services.Interfaces;

namespace ToDoApi.Services.Classes;

public class AuthService : IAuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IConfiguration _config;

    public AuthService(UserManager<IdentityUser> userManager, IConfiguration config)
    {
        _userManager = userManager;
        _config = config;
    }

    public async Task<bool> RegisterUser(LoginUser user)
    {
        var identityUser = new IdentityUser
        {
            UserName = user.Username,
            Email = user.Email
        };

        var result = await _userManager.CreateAsync(identityUser, user.Password);
        return result.Succeeded;
    }

    public async Task<bool> Login(LoginUser user)
    {
        var identityUser = await _userManager.FindByEmailAsync(user.Email);
        if (identityUser is null)
        {
            return false;
        }

        return await _userManager.CheckPasswordAsync(identityUser, user.Password);
    }

    public string GenerateTokenString(LoginUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Username),
            new Claim(ClaimTypes.Role, "Admin"),
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value));
        
        var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        
        var securityToken = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            issuer: _config.GetSection("Jwt:Issuer").Value,
            audience: _config.GetSection("Jwt:Audience").Value,
            signingCredentials: signingCred);
        
        string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
        return tokenString;

    }
}