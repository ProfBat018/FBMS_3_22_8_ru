namespace ApiFirst.Services.Interfaces;

public interface IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string message, FileInfo[] attachments=null, bool isHtml=false);
}
