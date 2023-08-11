using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N22
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Course(string title)
        {
            Title = title;
        }
    }
}
