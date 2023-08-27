using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N32_T2
{
    public class ChatMessage: AuditableEntity
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public Guid ChatId { get; set; }
        public override int GetHashCode()
        {
            return Subject.GetHashCode() + Message.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            return GetHashCode() == obj.GetHashCode();
        }
        public override string ToString()
        {
            return $"Subject: {Subject}\nMessage: {Message}\n";
        }
        public ChatMessage(string s, string m)
        {
            Id = Guid.NewGuid();
            Subject = s ;
            Message = m ;
            ChatId = Guid.NewGuid();
        }
    }
}
