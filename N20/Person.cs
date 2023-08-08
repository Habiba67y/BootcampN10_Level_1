using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N20
{
    internal class Person
    {
        public string Name { get; set; }
        public byte Age { get; set; }
        public bool IsMarried = false;
        public Person(string name, byte age) => (Name, Age) = (name, age);
        public string DisplayInfo()
        {
            return $"Name: {Name}\nAge: {Age}\nIsMarried: {IsMarried}";
        }
    }
}
