using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N16_T1
{
    internal class TemperatureService
    {
        private string _temperature;
        public List<string> temperatures = new List<string>();
        public string Temperature
        {
            set
            {
                _temperature = value + " gradus";
                temperatures.Add(_temperature);
            }
        }
        public void Display()
        {
            foreach (var t in temperatures)
            {
                Console.WriteLine(t);
            }
        }
    }
}
