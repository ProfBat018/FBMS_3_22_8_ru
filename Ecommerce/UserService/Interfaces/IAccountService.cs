using AuthData.DTO;

namespace UserService.Interfaces;

public interface IAccountService
{
    public Task ResetPaswordAsync(ResetPasswordDTO resetRequest, string token);
    public Task ConfirmEmailAsync(string token);
}
