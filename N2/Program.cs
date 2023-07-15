//Console.WriteLine("Tug'ilgan sanangizni kiriting: ");
//Console.Write("Kun: ");
//int day = Convert.ToInt32(Console.ReadLine());
//Console.Write("Oy: ");
//int month = Convert.ToInt32(Console.ReadLine());
//Console.Write("Yil: ");
//int year = Convert.ToInt32(Console.ReadLine());
//DateTime date = new DateTime(year, month, day);
//while (true)
//{
//    Console.Clear();
//    TimeSpan m = DateTime.Now - date;
//    Console.WriteLine(m);
//    Thread.Sleep(1000);
//}

//T1:
//Console.Write("Ism: ");
//string firstName = Console.ReadLine();
//Console.Write("Familiya: ");
//string lastName = Console.ReadLine();
//Console.Write("Yosh: ");
//byte age = Convert.ToByte(Console.ReadLine());
//Console.Write("Robot yoki robot emasligingizni bilish uchun quyidagi misolni yeching:\n5 + 6 = ");
//byte num = Convert.ToByte(Console.ReadLine());
//Console.WriteLine($"\nIsm: {firstName}\nFamiliya: {lastName}\nYosh: {age}\nRobot emasligingiz: {num==5+6}");

//T2:
//Console.WriteLine("I\nLove\nc#");

//T3
//Console.Write("Username: ");
//string uname=Console.ReadLine();
//Console.Write("Password: ");
//string password=Console.ReadLine();
//Console.Write("Application: ");
//string a=Console.ReadLine();
//string g="Dear {0}\vWe would like to inform you, that your password was changed.\nYour new password is {1}\vSincerely\n{2}";
//string fg=string.Format(g, uname, password, a);
//Console.Write(fg);

//T4
//Console.WriteLine(@"D:\Projects\_1_week\Tasks");

//T5
//Console.Write("Tekst kiriting: ");
//string text=Console.ReadLine();
//Console.WriteLine($"{text}\n{text.Length}\n{text[0]}");
//Console.Write("Index: ");
//int i=Convert.ToInt32(Console.ReadLine());
//Console.Write("Length: ");
//int l=Convert.ToInt32(Console.ReadLine());
//for(int j = i; j < l+1; j++) 
//{
//    Console.Write(text[j]);
//}