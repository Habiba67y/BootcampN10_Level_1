using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N23_T3
{
    public class Book
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public string Author { get; set; }
        public Book(string author, int rating, string name)
        {
            Name = name;
            Rating = rating;
            Author = author;
        }
        public override string ToString()
        {
            return $"Name: {Name} | Author: {Author} | Rating: {Rating}";
        }
    }
}
