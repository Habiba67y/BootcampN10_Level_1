using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N36_HT2.task_1
{//Product: A record with properties for a product's ID, name, and price.
    public record Product(Guid Id, string Name, float Price);
}
