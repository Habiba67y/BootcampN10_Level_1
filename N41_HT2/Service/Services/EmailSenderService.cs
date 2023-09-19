using N41_HT2.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace N41_HT2.Service.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private SmtpClient _smtp;
        private readonly object _lock = new();
        public EmailSenderService()
        {
            _smtp = new SmtpClient("smtp.gmail.com", 587);
            _smtp.Credentials = new NetworkCredential("sultonbek.rakhimov.recovery@gmail.com", "szabguksrhwsbtie");
            _smtp.EnableSsl = true;
        }
        public async ValueTask<bool> SendEmailAsync(string email)
        {
            var result = false;
            lock (_lock)
            {
                try
                {
                    var mail = new MailMessage("sultonbek.rakhimov@gmail.com", email);
                    mail.Subject = "Salam";
                    mail.Body = "Assalaamu a'laykum va rohmatullohi ta'ala va barokatuh!";
                    _smtp.Send(mail);
                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                }
            }
            Console.WriteLine($"{email} ga email jo'natildi");
            return result;
        }
    }
}
