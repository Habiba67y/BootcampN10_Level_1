using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N40_T1.Models
{
    public class Email
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public Email(string subject, string body)
        {
            Subject = subject;
            Body = body;
        }
    }
}
