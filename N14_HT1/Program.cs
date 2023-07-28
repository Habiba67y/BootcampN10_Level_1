var nm = new NotificationMessage();
nm.AddMessage("SuccRegistration", "You successfully registered");
nm.AddMessage("AskPassword", "Enter your password: ");
nm.AddMessage("Blocked", "Your account has been blocked");
Console.WriteLine("Enter your message name: ");
var n = Console.ReadLine();
nm.SearchMessage(n);

public class NotificationMessage
{
    private Dictionary<string, string> messages = new Dictionary<string, string>();
        protected KeyValuePair<string, string> FindMessage(string name)
    {
        foreach(var message in messages)
        {
            if (message.Key.Contains(name, StringComparison.OrdinalIgnoreCase))
            {
                return message;
            }
        }
        return new KeyValuePair<string, string>();
    }
    public void SearchMessage(string name)
    {
        if (!string.IsNullOrWhiteSpace(FindMessage(name).Key))
        {
            Console.WriteLine($"Name: {FindMessage(name).Key}\nContent: {FindMessage(name).Value}");
        }
        else
        {
            Console.WriteLine("There is no message");
        }
    }
    public void Display()
    {
        foreach (var message in messages) 
        {
            Console.WriteLine($"Name: {message.Key}\nContent: {message.Value}");
        }
    }
    public void AddMessage(string name, string content)
    {
        if (messages.ContainsKey(name))
        {
            Console.WriteLine("There is message named like that please rename your message");
        }
        else
        {
            messages.Add(name, content);
        }
    }
}