Console.WriteLine("Keling password yaratamiz!");
Console.WriteLine("Ha bo'lsa - {1} yo'q bo'lsa - {0}");
Console.Write("Katta harf bo'lsinmi: ");
int kattaHarf = Convert.ToInt32(Console.ReadLine());
Console.Write("Kichik harf bo'lsinmi: ");
int kichikHarf = Convert.ToInt32(Console.ReadLine());
Console.Write("Son bo'lsinmi: ");
int son = Convert.ToInt32(Console.ReadLine());
Console.Write("Simvol bo'lsinmi: ");
int simvol = Convert.ToInt32(Console.ReadLine());
Console.Write("Password uzunligi: ");
int lengthOfPassword = Convert.ToInt32(Console.ReadLine());
Random r = new Random();
for (int i = 0; i < lengthOfPassword; i++)
{
    var t = r.Next(1, 5);
    if (t == 1)
    {
        if (kattaHarf == 1)
        {
            Console.Write(Convert.ToChar(r.Next(65, 91)));
        }
        if (kattaHarf == 0)
        {
            i--;
        }
    }
    if (t == 2)
    {
        if (kichikHarf == 1)
        {
            Console.Write(Convert.ToChar(r.Next(97, 123)));
        }
        if (kichikHarf == 0)
        {
            i--;
        }
    }
    if (t == 3)
    {
        if (son == 1)
        {
            Console.Write(Convert.ToChar(r.Next(48, 58)));
        }
        if (son == 0)
        {
            i--;
        }
    }
    if (t == 4)
    {
        if (simvol == 1)
        {
            Console.Write(Convert.ToChar(r.Next(33, 48)));
        }
        if (simvol == 0)
        {
            i--;
        }
    }
}