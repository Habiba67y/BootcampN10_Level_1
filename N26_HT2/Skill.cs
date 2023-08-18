using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N26_HT2
{
    public class Skill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public SkillLevel Level { get; set; }
        public Skill(string name, SkillLevel level)
        {
            Id = Guid.NewGuid();
            Name = name;
            Level = level;
        }
        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}\nLevel: {Level}\n";
        }
    }
}
