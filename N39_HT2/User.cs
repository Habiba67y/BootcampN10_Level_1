using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N39_HT2
{
    public class User
    {        
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public User(string email, string password)
        {
            EmailAddress = email;
            Password = password;
        }
    }
}
