using ControllerFirst.DTO.Requests;

namespace ControllerFirst.Services.Interfaces;

public interface IAccountService
{
    public Task RegisterAsync(RegisterRequest request);
    public Task ConfirmEmailAsync(ConfirmRequest request, HttpContext context);
    public Task VerifyEmailAsync(string token);
}