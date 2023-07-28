Stack<string> browserHistory = new Stack<string>();
browserHistory.Push("https://example.com/page2");
browserHistory.Push("https://example.com/page1");
browserHistory.Push("https://example.com");
var index = browserHistory.Count()-1;
while (true)
{
    Console.WriteLine(browserHistory.ElementAt(index));
    Console.Write("Buyruqlarni tanlang:\nBack - b\nForward - f\nExit - e\n=> ");
    var b = Console.ReadLine();
    if (b == "b")
    {
        if (index == 0)
        {
            Console.WriteLine("Your browser history is empty");
        }
        else
        {
            index -= 1;
        }
    }
    else if (b == "f")
    {
        if (index == browserHistory.Count() - 1)
        {
            Console.WriteLine("You're currently in this site");
        }
        else
        {
            index += 1;
        }
    }
    else if (b == "e")
    {
        break;
    }
    else
    {
        Console.WriteLine("Xato buyruq!");
    }
}