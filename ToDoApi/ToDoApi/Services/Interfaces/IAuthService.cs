using ToDoApi.Models;

namespace ToDoApi.Services.Interfaces;

public interface IAuthService
{
    string GenerateTokenString(LoginUser user);
    Task<bool> Login(LoginUser user);
    Task<bool> RegisterUser(LoginUser user);
}