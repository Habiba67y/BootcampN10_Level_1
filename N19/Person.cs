using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N19
{
    internal class Person
    {
        private string name;
        private int age;
        private string city;
        static readonly string nationality;
        public Person(string n, string c, int a)
        {
            name = n;
            age = a;
            city = c;
        }
        public Person() { }
        static Person()
        {
            Console.WriteLine("Static");
            nationality = "Uzbek";
        }
        public Person(Person p)
        {
            name = p.name;
            age = p.age;
            city = p.city;
        }
        public override string ToString()
        {
            return $"Name: {name}\nAge: {age}\nCity: {city}";
        }
        
    }
}
