using N5;
using System.ComponentModel.Design;

List<student> Student = new List<student>()
{
    new student(){ Id = 1, FullName = "Abdulxayev Jasurbek Anvar O'g'li",  BirthDay = new DateTime(2005, 12, 12),  EduType = "DotNET", Payment = 2400000, PaymentAmount = 2000000 },
    new student(){ Id = 2, FullName = "Abdumannonov Botirjon Davlat O'g'li",  BirthDay = new DateTime(2004, 1, 17),  EduType = "Python", Payment = 1600000, PaymentAmount = 500000 },
    new student(){ Id = 3, FullName = "Abdurahmonov Azizbek Alisher O'g'li",  BirthDay = new DateTime(2003, 12, 12),  EduType = "DotNET", Payment = 2400000, PaymentAmount = 3000000 },
    new student(){ Id = 4, FullName = "Anvarjonov Ozodbek Avazxon O'g'li",  BirthDay = new DateTime(2003, 11, 1),  EduType = "SMM", Payment = 1450000, PaymentAmount = 2500000 },
    new student(){ Id = 5, FullName = "Asadov Firdavs Asqarbek O'g'li",  BirthDay = new DateTime(2006, 7, 18),  EduType = "Dizayn", Payment = 1900000, PaymentAmount = 0 },
    new student(){ Id = 6, FullName = "Eshmurodov Umarali Abduhalim O'g'li",  BirthDay = new DateTime(2005, 12, 12),  EduType = "SMM", Payment = 1450000, PaymentAmount = 900000 },
    new student(){ Id = 7, FullName = "Jo'raboyev Boburjon Murodjon O'g'li",  BirthDay = new DateTime(2007, 4, 12),  EduType = "Dizayn", Payment = 1900000, PaymentAmount = 2000000 },
    new student(){ Id = 8, FullName = "Karimjonov Ilhom Ramzjon O'g'li",  BirthDay = new DateTime(2005, 8, 1),  EduType = "DotNET", Payment = 2400000, PaymentAmount = 2500000 },
    new student(){ Id = 9, FullName = "Komiljonov Muhammadaziz Abduraximovich",  BirthDay = new DateTime(2002, 1, 12),  EduType = "Python", Payment = 1600000, PaymentAmount = 1500000 },
    new student(){ Id = 10, FullName = "Rashidov Asadbek",  BirthDay = new DateTime(2001, 3, 12),  EduType = "Dizayn", Payment = 1900000, PaymentAmount = 1900000 },
    new student(){ Id = 11, FullName = "Sadriddinov Abdurahmon Jurabek O'g'li",  BirthDay = new DateTime(2003, 5, 12),  EduType = "Python", Payment = 1600000, PaymentAmount = 1700000 },
    new student(){ Id = 12, FullName = "Sattorova Habiba Shuxrat Qizi",  BirthDay = new DateTime(2006, 2, 7),  EduType = "DotNET", Payment = 2400000, PaymentAmount = 2000000 },
    new student(){ Id = 14, FullName = "Tolibov Firdavs Odil O'g'li",  BirthDay = new DateTime(2003, 5, 6),  EduType = "DotNET", Payment = 2400000, PaymentAmount = 2700000 },
    new student(){ Id = 15, FullName = "To'rayev Dinur Alisher O'g'li",  BirthDay = new DateTime(2002, 8, 22),  EduType = "Python", Payment = 1600000, PaymentAmount = 2000000 },
    new student(){ Id = 16, FullName = "Vositov Muhammadrizo Muhammadtolib O'g'li",  BirthDay = new DateTime(2000, 11, 20),  EduType = "SMM", Payment = 1450000, PaymentAmount = 1400000 },
    new student(){ Id = 17, FullName = "Xaybullayev Mexroj Mansurjonovich",  BirthDay = new DateTime(2005, 2, 12),  EduType = "Dizayn", Payment = 1900000, PaymentAmount = 2000000 },
    new student(){ Id = 18, FullName = "Xolmuratov Qurbonali Suxrob O'g'li",  BirthDay = new DateTime(2006, 5, 9),  EduType = "DotNET", Payment = 2400000, PaymentAmount = 2400000 },
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
    Console.WriteLine("\n1 - Talabalar ro'yhati\n2 - To'lovlar\n3 - Balllar\n4 - Talaba qo'shish\n5 - Talaba olish\n");
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
                            Console.WriteLine($"\nID: {st.Id} FullName: {st.FullName} Age: {st.getAge()}");
                        }
                    }
                    break;
                case '2':
                    foreach (var st in Student)
                    {
                        if (st.EduType == "SMM")
                        {
                            Console.WriteLine($"\nID: {st.Id} FullName: {st.FullName} Age: {st.getAge()}");
                        }

                    }
                    break;
                case '3':
                    foreach (var st in Student)
                    {
                        if (st.EduType == "Python")
                        {
                            Console.WriteLine($"\nID: {st.Id} FullName: {st.FullName} Age: {st.getAge()}");
                        }

                    }
                    break;
                case '4':
                    foreach (var st in Student)
                    {
                        if (st.EduType == "Dizayn")
                        {
                            Console.WriteLine($"\nID: {st.Id} FullName: {st.FullName} Age: {st.getAge()}");
                        }

                    }
                    break;
                default: Console.WriteLine("\nXato buyruq!"); break;
            }
        }
        if (s == "2")
        {
            Console.WriteLine("1 - DotNET\n2 - SMM\n3 - Python\n4 - Dizayn\n");
            Console.Write("Tanlovingiz: ");
            char b = Console.ReadKey().KeyChar;
            Console.WriteLine($"\n№\tIsm-sharif\t\t\t\t\tTo'lov\t\tTo'langan\tQoldiq");
            switch (b)
            {
                case '1':
                    foreach (var item in Student)
                    {
                        item.GetTable("DotNET");
                    }
                    break;
                case '2':
                    foreach (var item in Student)
                    {
                        item.GetTable("SMM");
                    }
                    break;
                case '3':
                    foreach (var item in Student)
                    {
                        item.GetTable("Python");
                    }
                    break;
                case '4':
                    foreach (var item in Student)
                    {
                        item.GetTable("Dizayn");
                    }
                    break;
                default : Console.WriteLine("Xato buyruq");break;
            }
        }
        if (s == "3")
        {
            Console.WriteLine("№:\t\tIsm:\t\t\t\t\t11.07\t\t12.07\t\t13.07\t\t14.07");
            for (int i = 0; i < 17; i++)
            {
                 Console.Write(Student[i].Id + ")\t" + Student[i].FullName.PadRight(45, ' '));
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"\t{balls[i, j]}\t");
                }
                Console.WriteLine();
            }
        }
        if (s == "4")
        {
            Console.Write("F.I.O: ");
            string fio = Console.ReadLine();
            Console.Write("Education type: ");
            string edutype = Console.ReadLine();
            Student.Add(new student
            {
                Id = Student.Last().Id + 1,
                FullName = fio,
                BirthDay = DateTime.Now,
                EduType = edutype
            });
        }
        if (s == "5")
        {
            Console.WriteLine("Enter your ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            student item = new student();
            foreach (var st in Student)
            {
                if (st.Id == id)
                {
                    item = st;
                }
            }
            var index=Student.IndexOf(item);
            Student.RemoveAt(index);
        }
        if (s == "0")
        {
            break;
        }
    }
}


