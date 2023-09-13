using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37
{
    public record Student(string FirstName, string LastName, int Grade) : Person(FirstName, LastName);
}
