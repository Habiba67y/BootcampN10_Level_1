using N28_HT1.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N28_HT1.Models.Entities
{
    public class Event : IEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Event(string name, DateTime date)
        { 
            Id = Guid.NewGuid();
            Name = name;
            Date = date;
        }
        public override string ToString() 
        {
            return $"ID: {Id}\nName: {Name}\nDate: {Date}\n";
        }
    }
}
