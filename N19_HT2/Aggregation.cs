using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N19_HT2
{
    internal class Aggregation
    {
        public int Sum(params int[] values)
        {
            var sum = 0;
            foreach (var item in values)
            {
                sum+= item;
            }
            return sum;
        }
        public float Average(params int[] values)
        {
            var average = (float)Sum(values)/values.Length;
            return average;
        }
        public int Min(params int[] values)
        {
            var min = values[0];
            foreach (var item in values)
            {
                if (item < min)
                {
                    min = item;
                }
            }
            return min;
        }
        public int Max(params int[] values) 
        {
            var max = values[0];
            foreach (var item in values)
            {
                if (item > max) 
                {
                    max = item;
                }
            }
            return max;
        }
        public void Increament(ref int value)
        {
            if (value < int.MaxValue)
            {
                value += 1;
            }
        }
        public void Decreament(ref int value)
        {
            if (value > int.MinValue)
            {
                value -= 1;
            }
        }
    }
}
