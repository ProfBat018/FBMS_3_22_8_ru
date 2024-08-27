using ApiFirst.Data.Models;
using ApiFirst.Data.Models.Requests;

namespace ApiFirst.Services.Interfaces;

public interface IAuthService
{
    public Task<AccessInfoDTO> LoginUserAsync(LoginDTO user);
    public Task<User> RegisterUserAsync(RegisterDTO user);
    public Task<AccessInfoDTO> RefreshTokenAsync(TokenDTO userAccessData);

    public Task LogOutAsync(TokenDTO userTokenInfo);


}
