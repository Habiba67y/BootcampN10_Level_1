using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace N24_HT1
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public bool isDeleted { get; set; }
        public User(string firstName, string lastName, string emailAddress, bool isDeleted)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            this.isDeleted = isDeleted;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName} {EmailAddress}";
        }
    }
}
