using System.Net;
using System.Net.Mail;

// var recipients = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

var recipient = "azimov_e@itstep.org";
var subject = "Buenos Dias";
var messageString = "Elnur bes";

MailAddress fromAddress = new("profbat018@gmail.com", "Prof. Bat");
MailAddress toAddress = new(recipient);

MailMessage mailMessage = new(fromAddress, toAddress);

mailMessage.Subject = subject;

mailMessage.IsBodyHtml = true;
// Можно просто считать все из FileStream, далее взять строку с помощью StreamReader и вставить все в Body 
mailMessage.Body = $"""<html><body><h1>{messageString}</h1><img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ0cyduXNkqqHrdNMkJ2EqmncQbXgDri5sH6A&usqp=CAU"></img></body></html>""";

mailMessage.Attachments.Add(new("/Users/wayne/Documents/Work/FBMS_3_22_8_RU/MailProtocols/MailProtocols/img.png")); // MIME 

SmtpClient smtpClient = new("smtp.gmail.com", 587);

smtpClient.Credentials = new NetworkCredential("profbat018@gmail.com", "enasbuejovhcbsnj");
smtpClient.EnableSsl = true;

smtpClient.Send(mailMessage);

Console.WriteLine("Mail sent successfully");
