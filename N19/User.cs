using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N19
{
    internal class User
    {
        private string name;
        private int age;
        private string city;
        static readonly string nationality;
        public User(string n, string c, int a)
        {
            name = n;
            age = a;
            city = c;
        }
        public User() { }
        static User()
        {
            nationality = "Uzbek";
        }
        public User(User p)
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
