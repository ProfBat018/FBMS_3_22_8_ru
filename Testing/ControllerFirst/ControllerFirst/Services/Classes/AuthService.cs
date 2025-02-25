using AutoMapper;
using BCrypt.Net;
using ControllerFirst.Contexts;
using ControllerFirst.DTO.Requests;
using ControllerFirst.Data.Models;
using ControllerFirst.DTO.Responses;
using ControllerFirst.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using static BCrypt.Net.BCrypt;

namespace ControllerFirst.Services.Classes;

public class AuthService : IAuthService
{
    private readonly ITokenService _tokenService;
    private readonly AuthContext _context;
    private readonly IMapper _mapper;

    public AuthService(AuthContext context, ITokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }


    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var accessToken = await _tokenService.CreateTokenAsync(request.username);

        var refreshToken = Guid.NewGuid();
        var refreshTokenExpiration = DateTime.Now.AddDays(7);
        
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == request.username);
        
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiration = refreshTokenExpiration;
        
        await _context.SaveChangesAsync();
        
        return new LoginResponse(accessToken, refreshToken.ToString());
    }

    public async Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == request.username);
        
        if (user == null)
        {
            throw new Exception("User not found");
        }

        var oldRefreshTokenValidation = user.RefreshToken.ToString() == request.refreshToken
                                        && user.RefreshTokenExpiration > DateTime.Now;

        if (!oldRefreshTokenValidation)
            throw new Exception("Invalid refresh token");


        user.RefreshToken = Guid.NewGuid();
        user.RefreshTokenExpiration = DateTime.Now.AddDays(7);

        await _context.SaveChangesAsync();

        return new RefreshTokenResponse(
            await _tokenService.CreateTokenAsync(request.username),
            user.RefreshToken.ToString()
        );
    }
}