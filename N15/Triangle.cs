using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace N15
{
    internal class Triangle
    {
        public Triangle(double a, double b, double c)
        {
            if (isValidAngle(a, b, c))
            {
                A = a;
                B = b;
                C = c;
            }
            else
            {
                throw new ArgumentException("Bu tomonlardan uchburchak yasab bo'lmaydi!");
            }
        }
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }
        public double Perimetre { get => A + B + C; }
        public double Area
        {
            get
            {
                var p = Perimetre / 2;
                return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            }
        }
        private bool isValidAngle(double a, double b, double c)
        {
            return a < b + c && b < c + a && c < a + b;
        }
    }
}
