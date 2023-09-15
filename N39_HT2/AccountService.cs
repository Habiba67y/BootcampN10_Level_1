using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace N39_HT2
{
    public class AccountService
    {//AccountService ichida EmailService dan foydalaning, unda quyidagi exceptionlar bo'lsin
     //- agar argumentlar validatsiyadan o'tmasa - argument exception
     //- agar email service dagi send email dan false qaytsa - invalid operation exception
     //- agar shu email dagi user bo'lsa - exception
        public List<User> users;
        private readonly IEmailSenderService _emailSenderService;
        public AccountService()
        {
            users = new List<User>();
            _emailSenderService = new EmailSenderService();
        }
        public User Register(string emailAddress, string password)
        {
            var emailRegex = new Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");
            var passwordRegex = new Regex(@"^(.{6,}|[^0-9]*|[^A-Z])$");
            if (emailRegex.IsMatch(emailAddress) && passwordRegex.IsMatch(password))
            {
                if (users.FirstOrDefault(x => x.EmailAddress.Equals(emailAddress)) != null)
                    throw new Exception("Bunday email orqali allaqachon ro'yhatdan o'tilgan");
                if (!_emailSenderService.SendEmail(emailAddress))
                    throw new InvalidOperationException("Email jo'natishda qandaydir xatolik ketdi");
                var user = new User(emailAddress, password);
                users.Add(user);
                return user;
            }
            throw new ArgumentException("Email yoki password yaroqsiz");
        }
    }
}
