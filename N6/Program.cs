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

