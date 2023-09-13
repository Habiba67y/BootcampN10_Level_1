using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace N37_HT1
{

    public class EmailSenderService
    {
        public async Task SendEmailsAsync(IEnumerable<EmailMessage> messages)
        {
            var smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("sultonbek.rakhimov.recovery@gmail.com", "szabguksrhwsbtie");
            smtp.EnableSsl = true;
            foreach (var item in messages)
            {
                Console.WriteLine(item.Body);
                Console.WriteLine();
                var mail = new MailMessage(item.SendAddress, item.ReceiverAddress);
                mail.Subject = item.Subject;
                mail.Body = item.Body;
                await smtp.SendMailAsync(mail);
            }
        }
    }
}
