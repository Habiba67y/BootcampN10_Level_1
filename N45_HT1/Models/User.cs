using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N45_HT1.Models
{ 
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public User(string firstName)
        {            
            FirstName = firstName;
        }
    }
}
