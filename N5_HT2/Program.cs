Console.WriteLine("+ -> qo'shish\n- -> ayirish\n* -> ko'paytirish\n/ -> bo'lish\ne -> dasturdan chiqish");
Console.Write("Son kiriting: ");
var n = Convert.ToInt32(Console.ReadLine());
Console.Write("Buyruq kiriting: ");
string c = Console.ReadLine();
int n1;
while (c != "e")
{
    Console.Write("Son kiriting: ");
    n1 = Convert.ToInt32(Console.ReadLine());
    switch (c)
    {
        case "+":
            n += n1;
            break;
        case "-":
            n -= n1;
            break;
        case "*":
            n *= n1;
            break;
        case "/":
            n /= n1;
            break;
    }
    Console.WriteLine("Javobi: " + n);
    Console.Write("Buyruq kiriting: ");
    c = Console.ReadLine();
}
Console.WriteLine("Rahmat!");
