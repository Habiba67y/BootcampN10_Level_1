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
                var result = await SendAsync("sattorovahabiba00@gmail.com", "Confirmation", "Confirmation");
                Console.WriteLine($"{emp.FirstName} {emp.LastName} ga confirm email jo'natildi");
                return result;
            }
            );
            var createFiles = employees.Select(emp => Task.Run(() =>
            {
                var fileStream = File.Create($"{emp.FirstName} {emp.LastName}'s employment contract.docs");
                Console.WriteLine($"{emp.FirstName} uchun file ochildi");
                return fileStream;
            }));
            var sendBoard = (await Task.WhenAll(sendConfirmation)).ToList().Select(async x =>
            {
                var result = await SendAsync("sattorovahabiba00@gmail.com", "Welcome", "Welcomeon board");
                Console.WriteLine($"welcome on board emaili jo'natildi");
                return result;
            });
            var contractText = (await Task.WhenAll(createFiles)).ToList().Select(x =>
            {
                var text = $"{x.Name}, employment contract text";
                return x.WriteAsync(Encoding.UTF8.GetBytes(text));
            });
            var officePolicies = (await Task.WhenAll(sendBoard)).ToList().Select(async x =>
            {
                var result = await SendAsync("sattorovahabiba00@gmail.com", "Office Policies", "Office Policies");
                Console.WriteLine($"Office policies emaili jo'natildi");
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
