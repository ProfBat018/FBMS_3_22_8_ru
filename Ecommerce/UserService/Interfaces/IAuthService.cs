

using AuthData.DTO;
using AuthData.Models;

namespace UserService.Interfaces;

public interface IAuthService
{
    public Task<AccessInfoDTO> LoginUserAsync(LoginDTO user);
    public Task<User> RegisterUserAsync(RegisterDTO user);
    public Task<AccessInfoDTO> RefreshTokenAsync(TokenDTO userAccessData);

    public Task LogOutAsync(TokenDTO userTokenInfo);
}
