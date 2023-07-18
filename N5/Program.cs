//№1:
using N5;

List<student> Student = new List<student>()
{
    new student(){ Id = 1, FullName = "Abdulxayev Jasurbek Anvar O'g'li",  BirthDay = new DateTime(2005, 12, 12),  EduType = "DotNET", Payment = 2400000 },
    new student(){ Id = 2, FullName = "Abdumannonov Botirjon Davlat O'g'li",  BirthDay = new DateTime(2004, 1, 17),  EduType = "Python", Payment = 1600000 },
    new student(){ Id = 3, FullName = "Abdurahmonov Azizbek Alisher O'g'li",  BirthDay = new DateTime(2003, 12, 12),  EduType = "DotNET", Payment = 2400000 },
    new student(){ Id = 4, FullName = "Anvarjonov Ozodbek Avazxon O'g'li",  BirthDay = new DateTime(2003, 11, 1),  EduType = "SMM", Payment = 1450000 },
    new student(){ Id = 5, FullName = "Asadov Firdavs Asqarbek O'g'li",  BirthDay = new DateTime(2006, 7, 18),  EduType = "Dizayn", Payment = 1900000 },
    new student(){ Id = 6, FullName = "Eshmurodov Umarali Abduhalim O'g'li",  BirthDay = new DateTime(2005, 12, 12),  EduType = "SMM", Payment = 1450000 },
    new student(){ Id = 7, FullName = "Jo'raboyev Boburjon Murodjon O'g'li",  BirthDay = new DateTime(2007, 4, 12),  EduType = "Dizayn", Payment = 1900000 },
    new student(){ Id = 8, FullName = "Karimjonov Ilhom Ramzjon O'g'li",  BirthDay = new DateTime(2005, 8, 1),  EduType = "DotNET", Payment = 2400000 },
    new student(){ Id = 9, FullName = "Komiljonov Muhammadaziz Abduraximovich",  BirthDay = new DateTime(2002, 1, 12),  EduType = "Python", Payment = 1600000 },
    new student(){ Id = 10, FullName = "Rashidov Asadbek",  BirthDay = new DateTime(2001, 3, 12),  EduType = "Dizayn", Payment = 1900000 },
    new student(){ Id = 11, FullName = "Sadriddinov Abdurahmon Jurabek O'g'li",  BirthDay = new DateTime(2003, 5, 12),  EduType = "Python", Payment = 1600000 },
    new student(){ Id = 12, FullName = "Sattorova Habiba Shuxrat Qizi",  BirthDay = new DateTime(2006, 2, 7),  EduType = "DotNET", Payment = 2400000 },
    new student(){ Id = 14, FullName = "Tolibov Firdavs Odil O'g'li",  BirthDay = new DateTime(2003, 5, 6),  EduType = "DotNET", Payment = 2400000 },
    new student(){ Id = 15, FullName = "To'rayev Dinur Alisher O'g'li",  BirthDay = new DateTime(2002, 8, 22),  EduType = "Python", Payment = 1600000 },
    new student(){ Id = 16, FullName = "Vositov Muhammadrizo Muhammadtolib O'g'li",  BirthDay = new DateTime(2000, 11, 20),  EduType = "SMM", Payment = 1450000 },
    new student(){ Id = 17, FullName = "Xaybullayev Mexroj Mansurjonovich",  BirthDay = new DateTime(2005, 2, 12),  EduType = "Dizayn", Payment = 1900000 },
    new student(){ Id = 18, FullName = "Xolmuratov Qurbonali Suxrob O'g'li",  BirthDay = new DateTime(2006, 5, 9),  EduType = "DotNET", Payment = 2400000 },
};
int[,] balls = new int[,]
{
    { 90, 100, 75, 60 },
    { 100, 100, 70, 0 },
    { 90, 50, 60, 100 },
    { 60, 50, 100, 90 },
    { 100, 10, 75, 45 },
    { 55, 85, 70, 60 },
    { 95, 90, 40, 100 },
    { 80, 100, 100, 40 },
    { 65, 80, 100, 50 },
    { 80, 90, 100, 60 },
    { 90, 85, 65, 55 },
    { 100, 55, 90, 100 },
    { 80, 75, 90, 60 },
    { 90, 90, 100, 55 },
    { 100, 60, 90, 75 },
    { 90, 80, 50, 100 },
    { 100, 100, 60, 60 },
    { 90, 50, 80, 90 },
};
while (true)
{
    string s = Console.ReadLine();
    if (!string.IsNullOrEmpty(s))
    {
        if (s == "1")
        {
            Console.WriteLine("1 - DotNET\n2 - SMM\n3 - Python\n4 - Dizayn\n");
            Console.Write("Tanlovingiz: ");
            char b = Console.ReadKey().KeyChar;
            switch (b)
            {
                case '1':
                    foreach (var st in Student)
                    {
                        if (st.EduType == "DotNET")
                        {
                            Console.WriteLine($"\nID: {st.Id} FullName: {st.FullName} Age: {st.getAge}");
                        }
                    }
                    break;
                case '2':
                    foreach (var st in Student)
                    {
                        if (st.EduType == "SMM")
                        {
                            Console.WriteLine($"\nID: {st.Id} FullName: {st.FullName} Age: {st.getAge}");
                        }

                    }
                    break;
                case '3':
                    foreach (var st in Student)
                    {
                        if (st.EduType == "Python")
                        {
                            Console.WriteLine($"\nID: {st.Id} FullName: {st.FullName} Age: {st.getAge}");
                        }

                    }
                    break;
                case '4':
                    foreach (var st in Student)
                    {
                        if (st.EduType == "Dizayn")
                        {
                            Console.WriteLine($"\nID: {st.Id} FullName: {st.FullName} Age: {st.getAge}");
                        }

                    }
                    break;
                default: Console.WriteLine("\nXato buyruq!"); break;
            }
        }
        if (s == "3")
        {
            var n = "H";
            Console.WriteLine("{-7 0}", n);
            Console.WriteLine("№:\tIsm:\t\t11.07\t12.07\t13.07\t14.07");
            for (int i = 0; i < 18; i++)
            {
                var ism = Student[i].FullName.Split();
                Console.Write($"\n{Student[i].Id}){ism[0]} {ism[1][0]} -\t");
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"{balls[i, j]}\t");
                }
            }
        }
        if (s == "0")
        {
            break;
        }
    }
}


