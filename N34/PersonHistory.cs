using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N34
{
    public class PersonHistory
    {
        public int PersonId { get; set; }
        public string Activity { get; set; }
        public DateTime Time { get; set; }
        public PersonHistory(int id, string activity)
        {
            PersonId = id;
            Activity = activity;
            Time = DateTime.Now;
        }
    }
}
