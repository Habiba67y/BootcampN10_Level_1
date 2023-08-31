using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N34_T1
{
    public class CustomerFilter
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        public string? Country { get; set; }
        public CustomerFilter(string? firstName, string? lastName, string? country)
        {
            FirstName = firstName;
            LastName = lastName;
            Country = country;
        }
    }
}
