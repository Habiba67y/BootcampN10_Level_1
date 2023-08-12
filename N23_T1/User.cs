using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N23_T1
{
    public class User
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public User(string email, string pass) 
        {
            EmailAddress = email;
            Password = pass;
            IsEmailVerified = false;
            IsPhoneVerified = false;
        }
        public bool IsEmailVerified { get; set; }
        public bool IsPhoneVerified { get; set; }
        public override string ToString()
        {
            return $"Email: {EmailAddress} Password: {Password}";
        }
    }
}
