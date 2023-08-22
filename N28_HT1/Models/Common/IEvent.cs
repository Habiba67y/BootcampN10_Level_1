using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N28_HT1.Models.Common
{
    public interface IEvent
    {
        Guid Id { get; set; }
        string Name { get; set; }
        DateTime Date { get; set; }
    }
}
