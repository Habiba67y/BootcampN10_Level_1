using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N27_HT1
{
    public class User
    {
        public Guid Id { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public User(string email, string passw, bool isAdmin)
        {
            Id = Guid.NewGuid();
            EmailAddress = email;
            Password = passw;
            IsAdmin = isAdmin;
        }
        public override string ToString()
        {
            return $"{EmailAddress} - {Password}";
        }
    }
}
