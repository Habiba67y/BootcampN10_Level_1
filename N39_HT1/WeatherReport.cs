using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace N39_HT1
{
    public class WeatherReport
    {
        public string State { get; set; }
        public int Degree { get; set; }
        public WeatherReport(string state, int degree)
        {
            State = state;
            Degree = degree;
        }
        public override string ToString() 
        {
            return $"{State} {Degree}";
        }
    }
}
