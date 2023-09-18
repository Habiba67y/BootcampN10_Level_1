using N40_T1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace N40_T1.Service
{
    public class AccountService
    {
        public List<User> users = new();
        public List<Email> emails = new();
        public void Register(string firstName, string lastName, string email, string password)
        {
            var emailRegex = new Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");
            var passwordRegex = new Regex(@"^(.{6,}|[^0-9]*|[^A-Z])$");
            if (!emailRegex.IsMatch(email))
                throw new InvalidDataException("Invalid email address");
            if (!passwordRegex.IsMatch(password))
                throw new ArgumentException("Invalid password");
            if (users.FirstOrDefault(x => x.EmailAddress == email) != null)
                throw new Exception("User with this email already exists");
            users.Add(new User(firstName, lastName, email, password));
            emails.Add(new Email("Assalomu alaykum!", "{{FullName}}, ro'yhatdan o'tdingiz".Replace("{{FullName}}", $"{firstName} {lastName}")));
                
        }
    }
}
