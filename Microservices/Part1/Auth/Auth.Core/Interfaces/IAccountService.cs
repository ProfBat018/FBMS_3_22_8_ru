


using Auth.Application.DTO;

namespace Auth.Core.Interfaces;

public interface IAccountService
{
    public Task ResetPaswordAsync(ResetPasswordDTO resetRequest, string token);
    public Task ConfirmEmailAsync(string token);
}
