using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N17_HT2
{
    internal class Chat
    {
        public List<ChatMessage> Messages = new List<ChatMessage>();
        public Guid Add(string content)
        {
            if (MessageValidator.IsValid(content))
            {
                var m = new ChatMessage(content);
                Messages.Add(m);
                return m.Id;
            }
            else
            {
                throw new Exception("Invalid message!");
            }
        }
        public void Update(Guid id, string content)
        {
            foreach (var m in Messages)
            {
                if (m.Id == id)
                {
                    if (MessageValidator.IsValid(content))
                    {
                        Messages.Remove(m);
                        var m1 = new ChatMessage(m);
                        m1.Content = content;
                        Messages.Add(m1);
                        return;
                    }
                    else
                    {
                        throw new Exception("Invalid message!");
                    }
                }
            }
            throw new Exception("Invalid id!");
        }
        public void Display()
        {
            for (int i = 0; i < Messages.Count(); i++)
            {
                Console.WriteLine($"Content: {Messages[i].Content}\nSentTime: {Messages[i].SendTime}");
            }
        }
    }
}
