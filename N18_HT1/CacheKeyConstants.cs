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
            var max = 0;
            foreach (var item in orders)
            {
                if (item > max)
                {
                    max = item;
                }
            }
             return Convert.ToString(max) + "-max";
        }
        public static string Min(List<int> orders) 
        {
            var min = orders[0];
            foreach (var item in orders)
            {
                if (item < min)
                {
                    min = item;
                }
            }
            return Convert.ToString(min) + "-max";
        }
        public static string Sum(List<int> orders)
        {
            var sum = 0;
            foreach (var item in orders)
            {
                sum += item;
            }
            return Convert.ToString(sum) + "-max"; 
        }
    }
}
