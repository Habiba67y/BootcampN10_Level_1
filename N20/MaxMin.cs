using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N20
{
    internal class MaxMin
    {
        public void FindMaxMin(out int max, out int min, params int[] members)
        {
            max = members.Max();
            min = members.Min();
        }
    }
}
