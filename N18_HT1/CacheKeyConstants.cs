using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N18_HT1
{
    internal static class CacheKeyConstants
    {
        public static string Max(List<int> orders)
        {
             return Convert.ToString(orders.Max()) + "-max";
        }
        public static string Min(List<int> orders) 
        {
            return Convert.ToString(orders.Min()) + "-min";
        }
        public static string Sum(List<int> orders)
        {
            return Convert.ToString(orders.Sum()) + "-sum";
        }
    }
}
