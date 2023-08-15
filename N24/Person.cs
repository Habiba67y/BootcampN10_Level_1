using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N24
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
        public Person(int id, string name, byte age) 
        {
            Id = id;
            Name = name;
            Age = age;
        }
        public override string ToString()
        {
            return $"{Id} {Name} {Age} y.o";
        }
    }
}
