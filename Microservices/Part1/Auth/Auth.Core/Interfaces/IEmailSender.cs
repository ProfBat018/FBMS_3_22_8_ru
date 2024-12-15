using System.Net.Mail;

namespace Auth.Core.Interfaces;


public interface IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string message, Attachment? attachment = null);
}