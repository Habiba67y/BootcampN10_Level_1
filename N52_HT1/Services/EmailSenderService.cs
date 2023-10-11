using System.Net.Mail;
using System.Net;
using N52_HT1.Services.Interfaces;
using N52_HT1.Models;

namespace N52_HT1.Services;

public class EmailSenderService : IEmailSenderservice
{
    public SmtpClient SmtpClientInstance { get; init; }

    public EmailSenderService()
    {
        SmtpClientInstance = new SmtpClient("smtp.gmail.com", 587);
        SmtpClientInstance.Credentials = new NetworkCredential("sultonbek.rakhimov.recovery@gmail.com", "szabguksrhwsbtie");
        SmtpClientInstance.EnableSsl = true;
    }

    public async ValueTask<bool> SendAsync(User user)
    {
        var result = true;
        try
        {
            var mail = new MailMessage("sultonbek.rakhimov@gmail.com", user.EmailAddress);
            mail.Subject = "Welcome to our system!";
            mail.Body = "{{FullName}}!, wellcome to our system! You registered succesfully".Replace("{{FullName}}", $"{user.FirstName} {user.LastName}");

            await SmtpClientInstance.SendMailAsync(mail);
        }
        catch (Exception e)
        {
            result = false;
        }

        return result;
    }
}
