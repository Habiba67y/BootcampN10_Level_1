var cl = new ContactList();
cl.Contacts.Add(new Contact()
{
    FirstName = "Shuhrat",
    LastName = "Bozorov",
    PhoneNumber = "98 741 52 56",
    EmailAddress = "shuhratbazarov731@gmail.com"
});
cl.Contacts.Add(new Contact()
{
    FirstName = "Nozima",
    LastName = "Bozorova",
    PhoneNumber = "94 845 87 45",
    EmailAddress = "bazarovanozima86@gmail.com"
});
cl.Contacts.Add(new Contact()
{
    FirstName = "Muhammadsaid",
    LastName = "Sattorov",
    PhoneNumber = "96 742 69 84",
    EmailAddress = "Muhammadsaid891@gmail.com"
});
cl.Contacts.Add(new Contact()
{
    FirstName = "Malika",
    LastName = "Sattorova",
    PhoneNumber = "98 145 62 58",
    EmailAddress = "sattarovamalika111@gmail.com"
});
cl.Contacts.Add(new Contact()
{
    FirstName = "Maryam",
    LastName = "Sattorova",
    PhoneNumber = "98 842 32 48",
    EmailAddress = "maryamsattorova21@gmail.com"
});
while (true)
{
    Console.Write("\nChoose a comman:\n\ndisplay - d\nsearch - f\nexit - e\n\n=> ");
    var c = char.Parse(Console.ReadLine());
    if (c == 'd')
    {
        cl.Display(cl.Contacts);
    }
    else if (c == 'f')
    {
        Console.Write("name: ");
        cl.Search(Console.ReadLine());
    }
    else if (c == 'e')
    {
        break;
    }
    else
    {
        Console.WriteLine("Wrong command");
    }
}
public class ContactList
{
    public List<Contact> Contacts = new List<Contact>();
    public void Display(List<Contact> contacts)
    {
        foreach (var contact in contacts)
        {
            Console.WriteLine($"\nFirst name: {contact.FirstName}\nLast name: {contact.LastName}\nPhone number: {contact.PhoneNumber}\nEnail address: {contact.EmailAddress}");
        }
    }
    public void Search(string name)
    {
        foreach (var contact in Contacts)
        {
            if (contact.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"\nFirst name: {contact.FirstName}\nLast name: {contact.LastName}\nPhone number: {contact.PhoneNumber}\nEnail address: {contact.EmailAddress}");
            }
        }
    }
}
public class Contact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
}