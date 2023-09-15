using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace N39_HT2
{
    public class EmailSenderService: IEmailSenderService
    {
        public bool SendEmail(string emailAddress)
        {
            var result = true;
            try
            {
                var smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("sultonbek.rakhimov.recovery@gmail.com", "szabguksrhwsbtie");
                smtp.EnableSsl = true;

                var mail = new MailMessage("sultonbek.rakhimov@gmail.com", emailAddress);
                mail.Subject = "Register";
                mail.Body = "Siz registratsiyadan o'tdingiz";
                smtp.Send(mail);
            }
            catch (Exception ex) 
            {
                result = false;
            }
            return result;
        }
    }
}
