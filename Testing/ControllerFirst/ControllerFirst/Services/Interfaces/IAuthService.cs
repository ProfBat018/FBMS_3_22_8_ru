using ControllerFirst.DTO.Requests;
using ControllerFirst.Data.Models;
using ControllerFirst.DTO.Responses;

namespace ControllerFirst.Services.Interfaces;

public interface IAuthService
{
    
    public Task<LoginResponse> LoginAsync(LoginRequest request);
    
    public Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest request);
    
}