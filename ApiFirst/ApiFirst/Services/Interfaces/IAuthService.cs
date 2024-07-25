using ApiFirst.Data.Models;

namespace ApiFirst.Services.Interfaces;

public interface IAuthService
{
    public Task<User> LoginUserAsync(LoginUser user);
    public Task<User> RegisterUserAsync(RegisterUser user);
}
