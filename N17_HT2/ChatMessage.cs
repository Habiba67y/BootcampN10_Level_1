using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N17_HT2
{
    internal class ChatMessage
    {
        public Guid Id { get; set; }
        public DateTime SendTime { get; set; }
        public DateTime EditedTime { get; set; }
        public string Content { get; set; }
        public ChatMessage(string content) 
        {
            Content = content;
            SendTime = DateTime.Now;
            Id  = Guid.NewGuid();
        }
        public ChatMessage(ChatMessage cm)
        {
            Id = cm.Id;
            Content = cm.Content;
            SendTime = cm.SendTime;
            EditedTime = DateTime.Now;
        }
    }
}
