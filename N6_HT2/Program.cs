using System;

var namesOfEvents = new string[10]
 {
     "Ayollar kuni",
     "Navruz",
     "Qurbon hayiti",
     "Ramazon hayiti",
     "Mustaqillik kuni",
     "Ustozlar kuni",
     "Yangi yil",
     "Bolalar kuni",
     "Xotira va qadrlash kuni",
     "yana qanaqadir event, xullas boshqa topomadim",
 };
var datesOfEvents = new DateTime[10]
{
    new DateTime(2023, 03, 08),
    new DateTime(2023, 03, 21),
    new DateTime(2023, 06, 28),
    new DateTime(2023, 04, 21),
    new DateTime(2023, 09, 01),
    new DateTime(2023, 10, 01),
    new DateTime(2023, 12, 31),
    new DateTime(2023, 06, 01),
    new DateTime(2023, 05, 9),
    new DateTime(2023, 06, 02),
};
DateTime now = DateTime.Now;
var a = "";
DateTime d;
char c;
while (true)
{
    Console.WriteLine("\nQuyidaglardan bittasini tanlang\r\n " +
        " eventlarni saralash - 1\r\n " +
        " eventni nomi bo'yicha topish - 2\r\n " +
        " eventni vaqti bo'yicha topish - 3\r\n " +
        " kelayotgan eventlarni ko'rsatish - 4\r\n " +
        " o'tib ketgan eventlarni ko'rsatish - 5\r\n " +
        " kelayotgan eventlarni ko'rsatish ( yaqinligi bo'yicha ) - 6\r\n " +
        " o'tib ketgan eventlarni ko'rsatish ( yaqinligi bo'yicha ) - 7\r\n " +
        " dasturni yopish - 8");
    c = Convert.ToChar(Console.ReadLine());
    switch (c)
    {
        case '1':
            Console.WriteLine("Saralash turini tanlang \r\n event nomi bo'yicha - 1\r\n event vaqti bo'yicha - 2");
            char c1 = Convert.ToChar(Console.ReadLine());
            if (c1 == '1')
            {
                Console.WriteLine("O'sish - 1\nKamayish - 2\n");
                char c2 = Convert.ToChar(Console.ReadLine());
                if (c2 == '1')
                {
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = i + 1; j < 10; j++)
                        {
                            if (String.Compare(namesOfEvents[i], namesOfEvents[j]) > 0)
                            {
                                a = namesOfEvents[i];
                                d = datesOfEvents[i];
                                namesOfEvents[i] = namesOfEvents[j];
                                datesOfEvents[i] = datesOfEvents[j];
                                namesOfEvents[j] = a;
                                datesOfEvents[j] = d;
                            }
                        }
                        Console.WriteLine($"{namesOfEvents[i]}-{datesOfEvents[i]}");
                    }
                    Console.WriteLine($"{namesOfEvents[9]}-{datesOfEvents[9]}");
                }
                if (c2 == '2')
                {
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = i + 1; j < 10; j++)
                        {
                            if (String.Compare(namesOfEvents[i], namesOfEvents[j]) < 0)
                            {
                                a = namesOfEvents[i];
                                d = datesOfEvents[i];
                                namesOfEvents[i] = namesOfEvents[j];
                                datesOfEvents[i] = datesOfEvents[j];
                                namesOfEvents[j] = a;
                                datesOfEvents[j] = d;
                            }
                        }
                        Console.WriteLine($"{namesOfEvents[i]}-{datesOfEvents[i]}");
                    }
                    Console.WriteLine($"{namesOfEvents[9]}-{datesOfEvents[9]}");
                }
            }
            if (c1 == '2')
            {
                Console.WriteLine("O'sish - 1\nKamayish - 2\n");
                char c2 = Convert.ToChar(Console.ReadLine());
                if (c2 == '1')
                {
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = i + 1; j < 10; j++)
                        {
                            if (datesOfEvents[i].DayOfYear > datesOfEvents[j].DayOfYear)
                            {
                                a = namesOfEvents[i];
                                d = datesOfEvents[i];
                                namesOfEvents[i] = namesOfEvents[j];
                                datesOfEvents[i] = datesOfEvents[j];
                                namesOfEvents[j] = a;
                                datesOfEvents[j] = d;
                            }
                        }
                        Console.WriteLine($"{namesOfEvents[i]}-{datesOfEvents[i]}");
                    }

                }
                if (c2 == '2')
                {
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = i + 1; j < 10; j++)
                        {
                            if (datesOfEvents[i].DayOfYear < datesOfEvents[j].DayOfYear)
                            {
                                a = namesOfEvents[i];
                                d = datesOfEvents[i];
                                namesOfEvents[i] = namesOfEvents[j];
                                datesOfEvents[i] = datesOfEvents[j];
                                namesOfEvents[j] = a;
                                datesOfEvents[j] = d;
                            }
                        }
                        Console.WriteLine($"{namesOfEvents[i]}-{datesOfEvents[i]}");
                    }
                }
            }
            break;
        case '2':
            Console.Write("Event nomini kriting: ");
            var name = Console.ReadLine();
            for (int i = 0; i < 10; i++)
            {
                if (namesOfEvents[i].Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"{namesOfEvents[i]} - {datesOfEvents[i]}");
                }
            }
            break;
        case '3':
            Console.Write("Oy: ");
            int month = Convert.ToInt32(Console.ReadLine());
            Console.Write("Kun: ");
            int day = Convert.ToInt32(Console.ReadLine());
            DateTime date = new DateTime(2023, month, day);
            for (int i = 0; i < 10; i++)
            {
                if (DateTime.Compare(datesOfEvents[i], date) == 0)
                {
                    Console.WriteLine($"{namesOfEvents[i]} - {datesOfEvents[i]}");
                }
            }
            break;
        case '4':
            for (int i = 0; i < 10; i++)
            {
                if ((datesOfEvents[i].DayOfYear - now.DayOfYear) > 0)
                {
                    Console.WriteLine($"{namesOfEvents[i]} - {datesOfEvents[i]}");
                }
            }
            break;
        case '5':
            for (int i = 0; i < 10; i++)
            {
                if ((datesOfEvents[i].DayOfYear - now.DayOfYear) < 0)
                {
                    Console.WriteLine($"{namesOfEvents[i]} - {datesOfEvents[i]}");
                }
            }
            break;
        case '6':
            int min = 366;
            int index1 = 0;
            for (int i = 0; i < 10; i++)
            {
                if ((datesOfEvents[i].DayOfYear - now.DayOfYear) > 0)
                {
                    if ((datesOfEvents[i].DayOfYear - now.DayOfYear) < min)
                    {
                        min = datesOfEvents[i].DayOfYear;
                        index1 = i;
                    }
                }
            }
            Console.WriteLine($"{namesOfEvents[index1]} - {datesOfEvents[index1]}");
            break;
        case '7':
            int max = -366;
            int index2 = 0;
            for (int i = 0; i < 10; i++)
            {
                if ((datesOfEvents[i].DayOfYear - now.DayOfYear) < 0)
                {
                    if ((datesOfEvents[i].DayOfYear - now.DayOfYear) > max)
                    {
                        max = datesOfEvents[i].DayOfYear;
                        index2 = i;
                    }
                }
            }
            Console.WriteLine($"{namesOfEvents[index2]} - {datesOfEvents[index2]}");
            break;
    }
    if (c == '8')
    {
        break;
    }
}
Console.WriteLine("Rahmat!!!");