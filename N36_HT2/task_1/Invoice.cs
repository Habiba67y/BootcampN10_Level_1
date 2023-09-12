using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N36_HT2
{
    public record Invoice(Guid Id, string Customer, int Totatamount);
}
