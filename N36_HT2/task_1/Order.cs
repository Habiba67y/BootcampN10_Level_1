using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace N36_HT2
{
    public record Order(Guid Id, Customer Customer, int items);
}
