using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N15
{
    class Rectangle
    {
        public Rectangle(Point a, Point b, Point c, Point d)
        {
            A = a;
            B = b; 
            C = c;
            D = d;
        }
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }
        public Point D { get; set; }
        public double AB { get => GetLength(A, B); }
        public double BC { get => GetLength(B, C); }
        public double CD { get => GetLength(C, D); }
        public double DA { get => GetLength(D, A); }
        public double Perimetre { get => AB + BC + CD + DA; }
        public double Area { get => GetLength(A, B); }
        private double GetLength(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow((a.X - b.X), 2) + Math.Pow((a.Y - b.Y), 2));
        }
    }
}
