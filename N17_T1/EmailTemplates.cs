using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N17_T1
{
    internal class EmailTemplates
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public EmailTemplates(string s, string c)
        {
            Subject = s;
            Content = c;
        }
    }
}
