



using System.Net;
using System.Net.Mail;
using Auth.Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Auth.Application.Implementations;


public class EmailSender : IEmailSender
{
    private readonly IConfiguration _configuration;
    private readonly SmtpClient _smtpClient;
    public EmailSender(IConfiguration configuration)
    {
        _configuration = configuration;
      
        _smtpClient = new SmtpClient(_configuration["Email:Host"])
        {
            Port = int.Parse(_configuration["Email:Port"]),
            Credentials = new NetworkCredential(_configuration["Email:Username"], _configuration["Email:Password"]),
            EnableSsl = true
        };
    }



    public async Task SendEmailAsync(string email, string subject, string message, Attachment? attachment=null)
    {
        var mailMessage = new MailMessage
        {
            From = new MailAddress(_configuration["Email:Username"]),
            Subject = subject,
            Body = message,
            IsBodyHtml = true
        };

        if (attachment != null)
        {
            mailMessage.Attachments.Add(attachment);
        }

        mailMessage.To.Add(email);
        

        await _smtpClient.SendMailAsync(mailMessage);

    }
}
