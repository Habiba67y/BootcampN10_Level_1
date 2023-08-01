using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N16_HT2
{
    internal class Temperature
    {
        public float et { get; set; }
        public float ct { get; set; }
        public Temperature(float t1, float t2) 
        {
            et = t1;
            ct = t2;
        }
    }
}
