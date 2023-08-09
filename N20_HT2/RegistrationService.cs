using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace N20_HT2
{
    internal class RegistrationService: IRegistrationServive
    {
        private List<User> Users = new List<User>();
        private bool CheckName(string ism, string familiya, string sharif)
        {
            if(!string.IsNullOrWhiteSpace(ism) && !string.IsNullOrWhiteSpace(familiya) && !string.IsNullOrWhiteSpace(sharif))
            {
                return true;
            }
            return false;
        }
        private bool CheckEmailAddress(string emailAddress)
        {
            var emailAddressRegex = new Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");
            if (emailAddressRegex.IsMatch(emailAddress))
            {
                return true;
            }
            return false;
        }
        private void GenerateUserName(ref string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                Console.Write("siz username kiritmadingiz!\nIltimos username kiriting: ");
                username = Console.ReadLine();
            }
            else
            {
                var random = new Random();
                var numbers = "1234567890";
                username += numbers[random.Next(0, numbers.Length - 1)];
            }
        }
        private bool Add(string ism, string familiya, string sharif, string email, string username)
        {
            if (!CheckName(ism, familiya, sharif))
            {
                if (string.IsNullOrWhiteSpace(ism))
                {
                    Console.WriteLine("Invalid firstname");
                }
                if (string.IsNullOrWhiteSpace(familiya))
                {
                    Console.WriteLine("Invalid lastname");
                }
                if (string.IsNullOrWhiteSpace(sharif))
                {
                    Console.WriteLine("Invalid sharif");
                }
                return false;
            }
            if (!CheckEmailAddress(email))
            {
                Console.WriteLine("Invalid emaild address");
                return false;
            }

            while (true)
            { 
                var isUnique = true;
                foreach (var user in Users)
                {
                    if (username == user.Username)
                    {
                        isUnique = false;
                    }
                }
                if (string.IsNullOrWhiteSpace(username) || !isUnique)
                {
                    GenerateUserName(ref username);
                }
                else
                {
                    break;
                }
            }

            Users.Add(new User(ism, familiya, sharif, email, username));
            return true;
        }
        public void Register(string ism, string familiya, string sharif, string email, string username)
        {

            if (Add(ism, familiya, sharif, email, username) && SendEmail(ism, email))
            {
                foreach (var user in Users)
                {
                    if (username == user.Username)
                    {
                        user.IsActive = true;
                    }
                }
            }
        }
        private bool SendEmail(string ism, string receiverEmail) 
        {
            var senderEmail = "sultonbek.rakhimov.recovery@gmail.com";
            var senderPassword = "szabguksrhwsbtie";

            try
            {
                var mail = new MailMessage(senderEmail, receiverEmail);
                mail.Subject = "Siz muvaffaqiyatli registratsiyadan o'tdingiz";
                mail.Body = "Hurmatli {{User}}, siz sistemadan muvaffaqiyatli o'tdingiz".Replace("{{User}}", ism);
                var smtpClient = new SmtpClient("smtp.gmail.com", 587); // Replace with your SMTP server address and port
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }
        public void Display()
        {
            foreach (var user in Users)
            {
                Console.WriteLine(user.ToString());
            }
        }
    }
}
