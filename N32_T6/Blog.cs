using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N32_T6
{
    public class Blog
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public Blog(string t, string b)
        {
            Id =Guid.NewGuid();
            Title = t;
            Body = b;
        }
    }
}
