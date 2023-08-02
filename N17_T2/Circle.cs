using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N17_T2
{
    internal sealed class Circle: Shape
    {
        public double Radius { get; set; }
        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculateShape()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
