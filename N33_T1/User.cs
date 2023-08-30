using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N33_T1
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Id: {Id} Name: {Name}";
        }
    }
}
