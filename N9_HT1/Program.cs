using System.Text.RegularExpressions;

string[] emails = new string[5]
{
    "john.doe@example",
    "john.doe@example.com",
    "john.doe+tag@example.com",
    "john.doe@example…com",
    "john.doe@example.co.uk",
};
var emailAddressRegex = new Regex("^((\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)\\s*[;,.]{0,1}\\s*)+$");
var emailAddressPattern = @"^((\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\s*[;,.]{0,1}\s*)+$";
foreach (string email in emails)
{
    Console.WriteLine("{0} {1} a valid email.", email,
    emailAddressRegex.IsMatch(email) ? "is" : "is not");
}
