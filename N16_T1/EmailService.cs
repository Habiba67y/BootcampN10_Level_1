using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace N16_T1
{
    internal class EmailService
    {
        public string CredentialAddress { get; init; }
        public string CredentialPassword { get; init; }
        public EmailService(string ca, string cp) 
        {
            CredentialAddress = ca;
            CredentialPassword = cp;
        }
        public void SendEmail(string username, string receiverEmail)
        {
            var senderEmail = CredentialAddress;
            var senderPassword = CredentialPassword;

            var mail = new MailMessage(senderEmail, receiverEmail);
            mail.Subject = "Siz muvaffaqiyatli registratsiyadan o'tdingiz";
            mail.Body = "Hurmatli {{User}}, siz sistemadan muvaffaqiyatli o'tdingiz".Replace("{{User}}", username);

            var smtpClient = new SmtpClient("smtp.gmail.com", 587); // Replace with your SMTP server address and port
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtpClient.EnableSsl = true;

            smtpClient.Send(mail);
        }

    }
}
