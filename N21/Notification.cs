using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N21
{
    internal class Notification
    {
        public User Recipient { get; set; }
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }
        public Notification(User recipient, string message) 
        {
            Recipient = recipient;
            Message = message;
            TimeStamp = DateTime.Now;
        }
    }
}
