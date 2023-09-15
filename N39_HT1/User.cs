using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N39_HT1
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public override string ToString() 
        {
            return $"{FirstName} {LastName}";
        }
    }
}
