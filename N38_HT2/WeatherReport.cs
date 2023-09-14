using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N38_HT2
{
    public class WeatherReport
    {
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public float WindSpeed { get; set; }
        public DateTime ReportTime { get; set; }
    }
}
