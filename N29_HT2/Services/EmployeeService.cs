using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using N29_HT2.Models;
using Microsoft.VisualBasic;

namespace N29_HT2.Services
{
    public class EmployeeService
    {
        public List<Employee> employees = new List<Employee>();
        public async Task HireAsync()
        {
            var sendConfirmation = employees.Select(async emp =>
            {
                var result = await SendAsync("sattorovahabiba00@gmail.com",
                    "Confirm Your Email Address",
                    "Thank you for joining the team. To start your journey we need to first " +
                    "confirm your email address, please click on the following link to confirm your " +
                    "email address:\r\n\r\nIf you received this email mistakenly, please ignore this email." +
                    "\r\n\r\nThank you".Replace("{{Employee}}", emp.FirstName));
                Console.WriteLine($"{emp.FirstName} {emp.LastName} ga confirm email jo'natildi");
                return emp.FirstName;
            }
            );
            var createFiles = employees.Select( emp => Task.Run(() =>
            {
                var fileStream = File.Create($"{emp.FirstName} {emp.LastName}'s employment contract.docs");
                Console.WriteLine($"{emp.FirstName} uchun file ochildi");
                return fileStream;
            }));
            var sendBoard = (await Task.WhenAll(sendConfirmation)).ToList().Select(async x =>
            {
                var result = await SendAsync("sattorovahabiba00@gmail.com",
                    "Welcome to My Company",
                    "Dear {{Employee}},\r\n\r\nWe are thrilled to welcome you! We are excited" +
                    " to have you on board and look forward to working with you.\r\n\r\nAs a new" +
                    " member of our team, we want to make sure you have everything you need to get" +
                    " started. Please let us know if you have any questions or need any assistance." +
                    "\r\n\r\nWe wish you all the best in your new role and look forward to your contributions" +
                    " to our team.\r\n\r\nBest regards".Replace("{{Employee}}", x));
                Console.WriteLine($"{x} ga welcome on broad email jo'natildi");
                return x;
            });
            var contractText = (await Task.WhenAll(createFiles)).ToList().Select(x =>
            {
                var text = $"{x.Name}, employment contract text";
                return x.WriteAsync(Encoding.UTF8.GetBytes(text));
            });
            var officePolicies = (await Task.WhenAll(sendBoard)).ToList().Select(async x =>
            {
                var result = await SendAsync("sattorovahabiba00@gmail.com",
                    "Office Policies and Guidelines",
                    "Dear {{Employee}},\r\n\r\nAs a member of our team, it is important " +
                    "that you are aware of our office policies and guidelines. These policies " +
                    "are designed to ensure a safe and productive work environment for everyone." +
                    "\r\n\r\nPlease take a moment to review the attached document, which outlines " +
                    "our policies and guidelines. If you have any questions or concerns, please do " +
                    "not hesitate to reach out to us.\r\n\r\nThank you for your cooperation and adherence " +
                    "to our policies.\r\n\r\nBest regards".Replace("{{Employee}}", x));
                Console.WriteLine($"{x}ga Office policies emaili jo'natildi");
                return result;
            });
            Task.WaitAll(contractText.Select(x => x.AsTask()).ToArray());
            await Task.WhenAll(officePolicies);
        }
        public Task<bool> SendAsync(string receiverEmailAddress, string subject, string body)
        {
            return Task.Run(async () =>
            {
                var result = true;
                try
                {
                    var smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.Credentials = new NetworkCredential("sultonbek.rakhimov.recovery@gmail.com", "szabguksrhwsbtie");
                    smtp.EnableSsl = true;

                    var mail = new MailMessage("sultonbek.rakhimov@gmail.com", receiverEmailAddress);
                    mail.Subject = subject;
                    mail.Body = body;

                    await smtp.SendMailAsync(mail);
                }
                catch (Exception e)
                {
                    result = false;
                }

                return result;
            });
        }
    }
}
