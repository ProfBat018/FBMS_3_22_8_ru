using System.Security.Claims;
using ControllerFirst.DTO.Requests;

namespace ControllerFirst.Services.Interfaces;

public interface ITokenService
{
    public Task<string> GetNameFromToken(string token);
    public Task<string> CreateTokenAsync(string username);
    public Task<string> CreateEmailTokenAsync(string username);
    
    public Task<bool> ValidateEmailTokenAsync(string token);
}