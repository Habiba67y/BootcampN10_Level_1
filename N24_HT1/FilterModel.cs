using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N24_HT1
{
    public abstract class FilterModel
    {
        public  abstract int PageSize { get; set; }
        public abstract int PageToken { get; set; }
    }
}
