using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N32_T4
{
    public class Music
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SingerName { get; set; }
        public override int GetHashCode()
        {
            return Name.GetHashCode() + SingerName.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            return GetHashCode() == obj.GetHashCode();
        }
        public Music(string name, string singerName)
        {
            Name = name;
            SingerName = singerName;
        }
    }
}
