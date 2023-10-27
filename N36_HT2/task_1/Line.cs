using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N36_HT2.task_1
{
    public struct Line
    {
        public Point Start { get; set; }
        public Point End { get; set; }
        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }
    }
}
