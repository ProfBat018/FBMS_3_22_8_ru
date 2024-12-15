
using Auth.Application.DTO;
using Auth.Core.Models;

namespace Auth.Core.Interfaces;


public interface IAuthService
{
    public Task<AccessInfo_DTO> LoginUserAsync(LoginDTO user);
    public Task<User> RegisterUserAsync(RegisterDTO user);
    public Task<AccessInfo_DTO> RefreshTokenAsync(TokenDTO userAccessData);

    public Task LogOutAsync(TokenDTO userTokenInfo);
}
