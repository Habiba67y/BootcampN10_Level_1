using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N26_T2
{
    public class Meeting
    {
        public string Name { get; set; }
        public TimeSpan Time { get; set; }
        public static bool operator <(Meeting meeting1, Meeting meeting2)
        {
            return meeting1.Time < meeting2.Time;
        }
        public static bool operator >(Meeting meeting1, Meeting meeting2)
        {
            return meeting1.Time > meeting2.Time;
        }
        public Meeting(string name, TimeSpan time)
        {
            Name = name;
            Time = time;
        }
        public override string ToString()
        {
            return $"Name: {Name} | Time: {Time}";
        }
        public static TimeSpan operator +(Meeting meeting1, Meeting meeting2)
        {
            return meeting1 .Time+ meeting2.Time;
        }
    }
}
