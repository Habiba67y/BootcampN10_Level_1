using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37_HT1
{
    public class EmailMessage
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string SendAddress { get; set; }
        public string ReceiverAddress { get; set; }
        public EmailMessage(string subject, string body, string sendAddress, string receiverAddress)
        {
            Subject = subject;
            Body = body;
            SendAddress = sendAddress;
            ReceiverAddress = receiverAddress;
        }
    }
}
