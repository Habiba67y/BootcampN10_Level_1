using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N17_HT2
{
    internal class Chat
    {
        public List<ChatMessage> Messages  = new List<ChatMessage>();
        public void Add(string content)
        {
            if (!string.IsNullOrWhiteSpace(content))
            {
                Messages.Add(new ChatMessage(content));
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
                    if (!string.IsNullOrWhiteSpace(content))
                    {
                        Messages.Remove(m);
                        var m1 = new ChatMessage(content);
                        m1.Copy(m);
                        Messages.Add(m);
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
            for (int i = 0; i < Messages.Count() - 1; i++)
            {
                for (int j = i + 1; j < Messages.Count; j++)
                {
                    if (Messages[i].SendTime > Messages[j].SendTime)
                    {
                        var temp = Messages[i];
                        Messages[i] = Messages[j];
                        Messages[j] = temp;
                    }
                }
                Console.WriteLine($"Content: {Messages[i].Content}\nSentTime: {Messages[i].SendTime}");
            }
            Console.WriteLine($"Content: {Messages[Messages.Count()-1].Content}\nSentTime: {Messages[Messages.Count()-1].SendTime}");
        }

    }
}
