using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace N28_HT2.DataAccess
{
    public class CloneableList<T> : List<T>, ICloneable where T : ICloneable
    {
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
