using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5
{
    public class student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDay { get; set; }
        public int Payment { get; set; }
        public string EduType { get; set; }
        public bool IsPayable { get; set; }
        public int getAge()
        {
            return DateTime.Now.Year-BirthDay.Year;
        }
    }
}
