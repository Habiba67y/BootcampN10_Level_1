using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N36_HT1
{
    public record Employee(string FirstName, string LastName, string EmailAddress, string Password) : Person(FirstName, LastName);
}
