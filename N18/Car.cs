using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N18
{
    internal abstract class Car
    {
        public string Brand { get; init; }
        public int Year { get; init; }
        public string Color { get; set; }
        
        public virtual string Show()
        {
            return $"Brand: {Brand}\nYear: {Year}; Color: {Color}";    
        }
        public abstract void Drive();

    }
}
