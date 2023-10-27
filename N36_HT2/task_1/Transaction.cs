using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N36_HT2.task_1
{
    public record Transaction(Guid Id, DateTime Date, int Amount);
}
