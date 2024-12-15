using System.Security.Claims;
using System.Text;
using Auth.Application.DTO;
using Auth.Core.Interfaces;
using Auth.Infrastructure.Contexts;
using Auth.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;
using UserService.Exceptions;
using static BCrypt.Net.BCrypt;

namespace Auth.Application.Implementations;

public class AccountService : IAccountService
{
    private readonly IEmailSender emailSender;
    private readonly ITokenService tokenService;
    private readonly AuthContext context;

    public AccountService(IEmailSender emailSender, ITokenService tokenService, AuthContext context)
    {
        this.emailSender = emailSender;
        this.tokenService = tokenService;
        this.context = context;
    }


    public async Task ConfirmEmailAsync(string token)
    {
        var principal = tokenService.GetPrincipalFromToken(token, validateLifetime: true);

        var username = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        var user = context.Users.FirstOrDefault(u => u.Username == username);

        if (user == null)
        {
            throw new MyAuthException(AuthErrorTypes.UserNotFound, "User not found");
        }

        var confirmationToken = await tokenService.GenerateEmailTokenAsync(user.Id.ToString());

        var link =
            $"http://localhost:5046/api/v1/Account/ValidateConfirmation?token={confirmationToken}&userId={user.Id}";

        StringBuilder sb = new StringBuilder(await File.ReadAllTextAsync("./wwwroot/index.html"));

        sb.Replace("[name]", username);
        sb.Replace("href=\"#\"", $"href=\"{link}\"");

        await emailSender.SendEmailAsync(user.Email, "Email confirmation", sb.ToString());
    }

    public async Task ResetPaswordAsync(ResetPasswordDTO resetRequest, string token)
    {
        var principal = tokenService.GetPrincipalFromToken(token, validateLifetime: true);

        var username = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        var user = await context.Users.FirstOrDefaultAsync(u => u.Username == username);

        if (user == null)
        {
            throw new MyAuthException(AuthErrorTypes.UserNotFound, "User not found");
        }

        if (!Verify(resetRequest.OldPassword, user.Password))
        {
            throw new MyAuthException(AuthErrorTypes.InvalidCredentials, "Invalid credentials");
        }

        if (resetRequest.NewPassword != resetRequest.ConfirmNewPassword)
        {
            throw new MyAuthException(AuthErrorTypes.PasswordMismatch, "Passwords do not match");
        }

        user.Password = HashPassword(resetRequest.NewPassword);

        await emailSender.SendEmailAsync(user.Email, "Password Reset", "Your password has been reset");

        await context.SaveChangesAsync();
    }
}