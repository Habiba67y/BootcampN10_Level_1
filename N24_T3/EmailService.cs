using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N24_T3
{
    public class EmailService
    {
        public List<Email> emails = new List<Email>();
        public List<Email> GetBySender(string sender, int pageSize, int pageToken)
        {
            var email = emails.Where(email => email.SenderAddress.Contains(sender, StringComparison.OrdinalIgnoreCase)).OrderByDescending(email => email.Date).ToList();
            return email.Skip((pageToken-1)*pageSize).Take(pageSize).ToList();
        }
        public List<Email> GetByReceiver(string receiver, int pageSize, int pageToken)
        {
            var email = emails.Where(email => email.ReceiverAddress.Contains(receiver, StringComparison.OrdinalIgnoreCase)).OrderByDescending(email => email.Date).ToList();
            return email.Skip((pageToken - 1) * pageSize).Take(pageSize).ToList();
        }
        public List<Email> Get(EmailfFlterModel filter)
        {
            return emails.Where( email =>
            {
                return (filter.SenderAddress is null || email.SenderAddress.Equals(filter.SenderAddress))
                && (filter.ReceiverAddress is null || email.ReceiverAddress.Equals(filter.ReceiverAddress))
                && (filter.Date is null || email.Date.Equals(filter.Date));
            }
                ).Skip((filter.PageToken-1)*filter.PageSize).Take(filter.PageSize).ToList();
        }
    }
}
