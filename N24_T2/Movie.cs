using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N24_T2
{
    public class Movie
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int Rating { get; set; }
        public override string ToString()
        {
            return $"Name: {Name}, Author: {Author}, Rating: {Rating}";
        }
    }
}
