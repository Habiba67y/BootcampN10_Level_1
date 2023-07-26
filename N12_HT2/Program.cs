using System.Security.Cryptography;
using System.Text.RegularExpressions;
var email = new Email();
Console.Write("to: ");
email.To = Console.ReadLine();
Console.Write("from: ");
email.From = Console.ReadLine();
Console.Write("subject: ");
email.Subject = Console.ReadLine();
Console.Write("content: ");
email.Content = Console.ReadLine();
Console.WriteLine(email.ToString("t"));
Console.WriteLine(email.ToString("f"));
Console.WriteLine(email.ToString("s"));
Console.WriteLine(email.ToString("c"));
public class Email
{
    public string _to;
    public string _from;
    public string _subject;
    public string _content;
    public string To
    {
        get { return _to; }
        set
        {
            //           var emailRegex = new Regex("^((\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)\\s*[;,.]{0,1}\\s*)+$");
            if (Regex.IsMatch(value, "^((\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)\\s*[;,.]{0,1}\\s*)+$"))
            {
                _to = value;
            }
            else
            {
                throw new FormatException("Invalid email");
            }
        }
    }
    public string From
    {
        get { return _from; }
        set
        {
            //         var emailRegex = new Regex("^((\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)\\s*[;,.]{0,1}\\s*)+$");
            if (Regex.IsMatch(value, "^((\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)\\s*[;,.]{0,1}\\s*)+$"))
            {
                _from = value;
            }
            else
            {
                throw new FormatException("Invalid email");
            }
        }
    }
    public string Subject
    {
        get { return _subject; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                _subject = value;
            }
            else
            {
                throw new FormatException("Invalid subject");
            }
        }
    }
    public string Content
    {
        get { return _content; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                _content = value;
            }
            else
            {
                throw new FormatException("Invalid content");
            }
        }
    }
    public string ToString(string str)
    {
        switch (str)
        {
            case "t":
                return To;
                break;
            case "f":
                return From;
                break;
            case "s":
                return Subject;
                break;
            case "c":
                return Content;
                break;
            default:
                return "wrong command";
                break;
        }
    }
}