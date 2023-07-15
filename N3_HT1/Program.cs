////T1:
//Console.WriteLine("Keling password yasaymiz:");
//Console.WriteLine("Ha b'lsa {1} Yo'q bo'lsa {0}");
//Console.Write("Sonlar bo'lsinmi: ");
//byte son = Convert.ToByte(Console.ReadLine());
//Console.Write("Harflarlar bo'lsinmi: ");
//byte harf = Convert.ToByte(Console.ReadLine());
//Console.Write("Simvollar bo'lsinmi: ");
//byte simvol = Convert.ToByte(Console.ReadLine());
//Console.Write("Password uzunligi: ");
//int l = Convert.ToInt32(Console.ReadLine());
//int i = 0;
//string password = "";
//Random r = new Random();
//while (i < l)
//{
//    if (harf == 1)
//    {
//        if (i < l)
//        {
//            password += Convert.ToChar(r.Next(97, 122));
//            i++;
//        }
//    }
//    if (son == 1)
//    {
//        if (i < l)
//        {
//            password += Convert.ToChar(r.Next(48, 57));
//            i++;
//        }
//    }
//    if (simvol == 1)
//    {
//        if (i < l)
//        {
//            password += Convert.ToChar(r.Next(33, 47));
//            i++;
//        }
//    }
//}
//Console.WriteLine($"\nPassword: {password}");