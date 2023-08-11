using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N22_T2.Model
{
    public interface ITaskEvent
    {
        Guid Id { get; }
        string Name { get; }
        byte Priority { get; }
    }
}
