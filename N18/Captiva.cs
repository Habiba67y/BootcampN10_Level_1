using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N18
{
    internal class Captiva: Car
    {
        public static string passengers;
        public readonly int maxspeed = 100;
        public int startspeed = 0;
        public Captiva(string brand, int year)
        {
            Brand = brand;
            Year = year;
        }
        public override string Show()
        {
            return $"Brand: {Brand}\nYear: {Year}\nColor: {Color}\nMaxSpeed: {maxspeed}\n";
        }
        public override void Drive()
        {
            var r = new Random();
            while (startspeed < maxspeed)
            {
                startspeed += r.Next(1, 100-startspeed);
            }

        }
    }
}
