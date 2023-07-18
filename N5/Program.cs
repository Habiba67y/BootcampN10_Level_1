////№1:
//using N5;

//List<student> Student = new List<student>()
//{
//    new student(){ Id = 1, FullName = "Abdulxayev Jasurbek Anvar O'g'li",  Age = 18,  EduType = "DotNET", Payment = 2400000, IsPayable = true },
//    new student(){ Id = 2, FullName = "Abdumannonov Botirjon Davlat O'g'li",  Age = 20,  EduType = "Python", Payment = 2300000, IsPayable = false},
//    new student(){ Id = 3, FullName = "Abdurahmonov Azizbek Alisher O'g'li",  Age = 21,  EduType = "DotNET", Payment = 2200000, IsPayable = true },
//    new student(){ Id = 4, FullName = "Anvarjonov Ozodbek Avazxon O'g'li",  Age = 16,  EduType = "SMM", Payment = 2100000, IsPayable = true},
//    new student(){ Id = 5, FullName = "Asadov Firdavs Asqarbek O'g'li",  Age = 17,  EduType = "Dizayn", Payment = 2000000, IsPayable = false },
//    new student(){ Id = 6, FullName = "Eshmurodov Umarali Abduhalim O'g'li",  Age = 23,  EduType = "SMM", Payment = 1900000 , IsPayable = false},
//    new student(){ Id = 7, FullName = "Jo'raboyev Boburjon Murodjon O'g'li",  Age = 22,  EduType = "Dizayn", Payment = 1800000 , IsPayable = true},
//    new student(){ Id = 8, FullName = "Karimjonov Ilhom Ramzjon O'g'li",  Age = 21,  EduType = "DotNET", Payment = 1800000 , IsPayable = true},
//    new student(){ Id = 9, FullName = "Komiljonov Muhammadaziz Abduraximovich",  Age = 19,  EduType = "Python", Payment = 1800000 , IsPayable = true},
//    new student(){ Id = 10, FullName = "Rashidov Asadbek",  Age = 20,  EduType = "Dizayn", Payment = 1800000    , IsPayable = false},
//    new student(){ Id = 11, FullName = "Sadriddinov Abdurahmon Jurabek O'g'li",  Age = 19,  EduType = "Python", Payment = 1900000 , IsPayable = false},
//    new student(){ Id = 12, FullName = "Sattorova Habiba Shuxrat Qizi",  Age = 17,  EduType = "DotNET", Payment = 1800000, IsPayable = false },
//    new student(){ Id = 14, FullName = "Tolibov Firdavs Odil O'g'li",  Age = 24,  EduType = "DotNET", Payment = 2000000, IsPayable = true },
//    new student(){ Id = 15, FullName = "To'rayev Dinur Alisher O'g'li",  Age = 21,  EduType = "Python", Payment = 2100000 , IsPayable = true},
//    new student(){ Id = 16, FullName = "Vositov Muhammadrizo Muhammadtolib O'g'li",  Age = 25,  EduType = "SMM", Payment = 2200000, IsPayable = true },
//    new student(){ Id = 17, FullName = "Xaybullayev Mexroj Mansurjonovich",  Age = 16,  EduType = "Dizayn", Payment = 2300000, IsPayable = true },
//    new student(){ Id = 18, FullName = "Xolmuratov Qurbonali Suxrob O'g'li",  Age = 23,  EduType = "DotNET", Payment = 2400000, IsPayable = false },
//};
//while (true)
//{
//    string s = Console.ReadLine();
//    if (!string.IsNullOrEmpty(s))
//    {
//        if (s == "1")
//        {
//            Console.WriteLine("1 - DotNET\n2 - SMM\n3 - Python\n4 - Dizayn\n");
//            Console.Write("Tanlovingiz: ");
//            char b = Console.ReadKey().KeyChar;
//            switch (b)
//            {
//                case '1':
//                    foreach (var st in Student)
//                    {
//                        if (st.EduType == "DotNET")
//                        {
//                            Console.WriteLine($"\nID: {st.Id} FullName: {st.FullName} Age: {st.Age}");
//                        }
//                    }
//                    break;
//                case '2':
//                    foreach (var st in Student)
//                    {
//                        if (st.EduType == "SMM")
//                        {
//                            Console.WriteLine($"\nID: {st.Id} FullName: {st.FullName} Age: {st.Age}");
//                        }

//                    }
//                    break;
//                case '3':
//                    foreach (var st in Student)
//                    {
//                        if (st.EduType == "Python")
//                        {
//                            Console.WriteLine($"\nID: {st.Id} FullName: {st.FullName} Age: {st.Age}");
//                        }

//                    }
//                    break;
//                case '4':
//                    foreach (var st in Student)
//                    {
//                        if (st.EduType == "Dizayn")
//                        {
//                            Console.WriteLine($"\nID: {st.Id} FullName: {st.FullName} Age: {st.Age}");
//                        }

//                    }
//                    break;
//                default: Console.WriteLine("\nXato buyruq!"); break;
//            }
//        }
//        if(s == "0")
//        {
//            break;
//        }
//    }
//}


//№2:
string[] names = new string[10]
{
    "Malika",
    "Parizoda",
    "Maryam",
    "Madina",
    "Muhammadsaid",
    "Nozima",
    "Habiba",
    "MuhammadAli",
    "Muslima",
    "Abdurahmon"
};
DateTime[] birthdays = new DateTime[10]
{
    new DateTime(2011, 09, 01),
    new DateTime(2004, 05, 18),
    new DateTime(2021, 09, 27),
    new DateTime(2006, 12, 27),
    new DateTime(2008, 09, 01),
    new DateTime(1986, 06, 05),
    new DateTime(2006, 06, 02),
    new DateTime(2014, 05, 25),
    new DateTime(2016, 07, 21),
    new DateTime(2014, 04, 14)
};
DateTime b;
string n;
for (int i = 0; i < 9; i++)
{
    for (int j = i + 1; j < 10; j++)
    {
        if (birthdays[i].DayOfYear > birthdays[j].DayOfYear)
        {
            b = birthdays[i];
            n = names[i];
            birthdays[i] = birthdays[j];
            names[i] = names[j];
            birthdays[j] = b;
            names[j] = n;
        }
    }
}
for (int k = 0; k < 10; k++)
{
    Console.Write(names[k]);
    Console.WriteLine(": " + birthdays[k]);
}