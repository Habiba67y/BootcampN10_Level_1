using N32_T2;
using System.Threading.Tasks.Dataflow;

var messageList = new List<ChatMessage>
{
    new ChatMessage("nimadir", "nimadir"),
    new ChatMessage("yana", "yana nimadir"),
    new ChatMessage("ish qilib", "yana nimadir"),
    new ChatMessage("nimadir", "nimadir"),
};
Console.WriteLine("Messages: ");
messageList.ForEach(Console.WriteLine);
for (int i = 0; i < messageList.Count - 1; i++)
{
    for (int j = i + 1; j < messageList.Count; j++)
    {
        if (messageList[i].Equals(messageList[j]))
        {
            Console.WriteLine($"Equals:\n{messageList[i]}\n{messageList[j]}");
        }
    }
}