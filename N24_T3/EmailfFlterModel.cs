using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N24_T3
{
    public class EmailfFlterModel
    {
        public string? ReceiverAddress { get; set; }
        public string? SenderAddress { get; set;}
        public DateTime? Date { get; set; }
        public int PageSize { get; set; }
        public int PageToken { get; set; }
        public EmailfFlterModel(string? receiverAddress, string? senderAddress, DateTime? date, int pageSize, int pageToken)
        {
            ReceiverAddress = receiverAddress;
            SenderAddress = senderAddress;
            Date = date;
            PageSize = pageSize;
            PageToken = pageToken;
        }
    }
}
