using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;

namespace LeaveManagement.Web.Services;

public class EmailSender : IEmailSender
{
    private readonly string smtpServer;
    private readonly int smtpPort;
    private readonly string fromAddress;

    public EmailSender(string smtpServer, int smtpPort, string fromAddress)
    {
        this.smtpServer = smtpServer;
        this.smtpPort = smtpPort;
        this.fromAddress = fromAddress;
    }

    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var message = new MailMessage
        {
            From = new MailAddress(fromAddress),
            Subject = subject,
            Body = htmlMessage,
            IsBodyHtml = true
        };

        message.To.Add(new MailAddress(email));

        using var client = new SmtpClient(smtpServer, smtpPort);
        client.Send(message);

        return Task.CompletedTask;
    }
}
