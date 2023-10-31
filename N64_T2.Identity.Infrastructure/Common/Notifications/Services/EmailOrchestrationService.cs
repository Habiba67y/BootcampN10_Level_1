using Microsoft.Extensions.Options;
using N64_T2.Identity.Application.Common.Notifications.Servcies;
using N64_T2.Identity.Application.Common.Settings;
using System.Net.Mail;
using System.Net;

namespace N64_T2.Identity.Infrastructure.Common.Notifucations.Services;

public class EmailOrchestrationService : IEmailOrchestrationService
{
    private readonly EmailSenderSettings _emailSenderSettings;

    public EmailOrchestrationService(IOptions<EmailSenderSettings> emailSenderSettings)
    {
        _emailSenderSettings = emailSenderSettings.Value;
    }

    public ValueTask<bool> SendAsync(string emailAddress, string message)
    {
        var result = true;
        try
        {
            var mail = new MailMessage(_emailSenderSettings.CredentialAddress, emailAddress);
            mail.Subject = "Siz muvaffaqiyatli registratsiyadan o'tdingiz";
            mail.Body = message;

            var smtpClient = new SmtpClient(_emailSenderSettings.Host, _emailSenderSettings.Port); // Replace with your SMTP server address and port
            smtpClient.Credentials = new NetworkCredential(_emailSenderSettings.CredentialAddress, _emailSenderSettings.Password);
            smtpClient.EnableSsl = true;

            smtpClient.Send(mail);
        }
        catch (Exception ex)
        {
            result = false;
        }

        return new(result);
    }
}
