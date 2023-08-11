using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Model
{
    public class Notification
    {
        public User Recipient { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
    }
}
