using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N36_HT2.task_1
{
    public struct Circle
    {
        public float Radius { get; set; }
        public Point CenterPoint { get; set; }
        public Circle(float radius, Point centerPoint)
        {
            Radius = radius;
            CenterPoint = centerPoint;
        }
    }
}
