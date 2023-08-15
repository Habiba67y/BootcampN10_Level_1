using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N24_T3
{
    public class Email
    {
        public string ReceiverAddress { get; set; }
        public string SenderAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public bool isClassified { get; set; }
        public Email(string receiverAddress, string senderAddress, string subject, string body, DateTime date, bool isclassified)
        {
            ReceiverAddress = receiverAddress;
            SenderAddress = senderAddress;
            Subject = subject;
            Body = body;
            Date = date;
            isClassified = isclassified;
        }
        public override string ToString()
        {
            return $"{SenderAddress} to {ReceiverAddress} at {Date} about {Subject}";
        }
    }
}
