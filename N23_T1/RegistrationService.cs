using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N23_T1
{
    public class RegistrationService
    {
        private List<User> users = new List<User>();
        public void Register(string email, string password)
        {
            if (users.Any(user => user.EmailAddress.Equals(email, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Bu email address allaqachon bor");
                
                return;
            }

            //foreach(var item in users)
            //{
            //    if (item.EmailAddress.Equals(email, StringComparison.OrdinalIgnoreCase))
            //    {
            //        Console.WriteLine("Bu email address allaqachon bor");
            //        return;
            //    }
            //}
            var user = new User(email, password);
            users.Add(user);
            user.IsEmailVerified = true;
            user.IsPhoneVerified = true;
        }
        public bool Login(string email, string pass)
        {
            var user = users.FirstOrDefault(user => user.EmailAddress == email && user.Password == pass);
            if (user != null)
            {
                if (!user.IsPhoneVerified || !user.IsEmailVerified)
                {
                    Console.WriteLine("Sorry, you haven't verified your email address / phone number");
                    return false;
                }
                return true;
            }
            return false;
        }
        public void Show()
        {
            foreach (var item in users)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
