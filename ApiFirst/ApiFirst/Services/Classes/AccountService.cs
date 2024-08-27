using ApiFirst.Data.Contexts;
using ApiFirst.Data.Models;
using ApiFirst.Data.Models.Requests;
using ApiFirst.Exceptions;
using ApiFirst.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;
using static BCrypt.Net.BCrypt;

namespace ApiFirst.Services.Classes;

public class AccountService : IAccountService
{
    private readonly IEmailSender emailSender; // Для отправки сообщения на почту. 
    private readonly ITokenService tokenService; // Для генерирования  одноразового токена пользователя. 
    private readonly AuthContext context; // Мой БД 

    public AccountService(IEmailSender emailSender, ITokenService tokenService, AuthContext context)
    {
        this.emailSender = emailSender;
        this.tokenService = tokenService;
        this.context = context;
    }


    public async Task ConfirmEmailAsync(string token)
    {
        var principal = tokenService.GetPrincipalFromToken(token, validateLifetime: true); // Забираю все информацию из токена 

        var username = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value; // Нахожу username 

        var user = context.Users.FirstOrDefault(u => u.Username == username); // Беру пользователя из БД

        if (user == null)
        {
            throw new MyAuthException(AuthErrorTypes.UserNotFound, "User not found");
        }

        // Создал токен для подтверждегия почты 
        var confirmationToken = await tokenService.GenerateEmailTokenAsync(user.Id.ToString());

        var link = $"http://localhost:5021/api/v1/Account/ValidateConfirmation?token={confirmationToken}";

        
        StringBuilder sb = new( File.ReadAllText("/Users/wayne/Documents/Work/FBMS_3_22_1_ru/ApiFirst/ApiFirst/assets/email.html"));
        
        sb.Replace("[Confirmation Link]", link);
        sb.Replace("[Year]", DateTime.Now.Year.ToString());
        sb.Replace("[Recipient's Name]", user.Username);
        sb.Replace("[Your Company Name]", "JWT Identity");
        
        await emailSender.SendEmailAsync(user.Email, "Email confirmation", sb.ToString(), isHtml: true);
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
