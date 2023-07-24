using System.Text.RegularExpressions;
var v = new Validator();
Console.Write("Your age: ");
Console.WriteLine(v.isValidAge(Console.ReadLine()));
Console.Write("Your first name: ");
Console.WriteLine(v.isValidFirstName(Console.ReadLine()));
Console.Write("Your last name: ");
Console.WriteLine(v.isValidLastName(Console.ReadLine()));
Console.Write("Your email address: ");
Console.WriteLine(v.isValidEmailaddress(Console.ReadLine()));
Console.Write("Your phone number: ");
Console.WriteLine(v.isValidPhoneNumber(Console.ReadLine()));
public class Validator
{
    public bool isValidAge(string age)
    {
        if (!string.IsNullOrWhiteSpace(age))
        {
            var ageRegex = new Regex("^(?:1[01][0-9]|120|[1-9][0-9]|[1-9])$");
            return ageRegex.IsMatch(age);
        }
        return false;
    }
    public bool isValidFirstName(string firstname)
    {
        if (!string.IsNullOrWhiteSpace(firstname))
        {
            var firstNameRegex = new Regex("^[^0-9_!¡?÷?¿/\\\\+=@#$%ˆ&*(){}|~<>;:[\\] ]{2,}$");
            return firstNameRegex.IsMatch(firstname);
        }
        return false;
    }
    public bool isValidLastName(string lastname)
    {
        if (!string.IsNullOrWhiteSpace(lastname))
        {
            var lastNameRegex = new Regex("^[^0-9_!¡?÷?¿/\\\\+=@#$%ˆ&*(){}|~<>;:[\\] ]{1,}$");
            return lastNameRegex.IsMatch(lastname);
        }
        return false;
    }
    public bool isValidEmailaddress(string email)
    {
        if (!string.IsNullOrWhiteSpace(email))
        {
            var emailRegex = new Regex("^((\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)\\s*[;,.]{0,1}\\s*)+$");
            return emailRegex.IsMatch(email);
        }
        return false;
    }
    public bool isValidPhoneNumber(string phonenumber)
    {
        if (!string.IsNullOrWhiteSpace(phonenumber))
        {
            var phoneNumberRegex = new Regex("^\\+\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$");
            return phoneNumberRegex.IsMatch(phonenumber);
        }
        return false;
    }
}