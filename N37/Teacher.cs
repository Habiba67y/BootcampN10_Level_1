using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37
{
    public record Teacher(string FirstName, string LastName, int Experience) : Person(FirstName, LastName);
}
