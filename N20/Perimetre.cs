using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N20
{
    internal class Perimetre
    {
        public void GetArea(int a, int b, out int P, out int S)
        {
            P = 2*(a+b);
            S = a*b;
        }
    }
}
