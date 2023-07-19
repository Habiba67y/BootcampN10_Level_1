TimeOnly boshlanishVaqti = new TimeOnly(8, 00);
TimeOnly tugashVaqti = new TimeOnly(20, 30);
var meetingsDateTime = new DateTime[10]
{
    new DateTime(2023, 07, 17, 9, 30, 00),
    new DateTime(2023, 07, 19, 11, 0, 0),
    new DateTime(2023, 07, 21, 12, 30, 0),
    new DateTime(2023, 07, 17, 13, 30, 0),
    new DateTime(2023, 07,19, 22, 25, 0),
    new DateTime(2023, 07,20, 21, 00, 0),
    new DateTime(2023, 07, 18, 16, 30, 0),
    new DateTime(2023,07, 22,  14, 00, 0),
    new DateTime(2023, 07, 20, 12, 00, 0),
    new DateTime(2023, 07, 18, 7, 00, 0),
};
var meetingsTimeSpan = new TimeSpan[10]
{
    TimeSpan.FromMinutes(30),
    TimeSpan.FromMinutes(25),
    TimeSpan.FromMinutes(40),
    TimeSpan.FromMinutes(15),
    TimeSpan.FromMinutes(60),
    TimeSpan.FromMinutes(50),
    TimeSpan.FromMinutes(10),
    TimeSpan.FromMinutes(30),
    TimeSpan.FromMinutes(20),
    TimeSpan.FromMinutes(45),
};
Console.WriteLine("bad meetings: ");
for (int i = 0; i < 10; i++)
{
    if ((meetingsDateTime[i].Hour < boshlanishVaqti.Hour) || (meetingsDateTime[i].Hour > tugashVaqti.Hour) || ((meetingsDateTime[i] + meetingsTimeSpan[i]).Hour > tugashVaqti.Hour))
    {
        Console.WriteLine($"{i + 1}-meeting - it's at {meetingsDateTime[i]} and its time is {meetingsTimeSpan[i]} ");
    }
}
Console.WriteLine("\nMeeting that its time is longer than 30 minutes:");
for (int i = 0; i < 10; i++)
{
    if (meetingsTimeSpan[i] > TimeSpan.FromMinutes(30))
    {
        Console.WriteLine($"{i + 1}-meeting - it's at {meetingsDateTime[i]} and its time is {meetingsTimeSpan[i]} ");
    }
}
Console.WriteLine("\nTotal time of meetings:");
TimeSpan c = TimeSpan.FromMinutes(0);
for (int i = 0; i < 10; i++)
{
    c += meetingsTimeSpan[i];
}
Console.WriteLine(c);
var max = meetingsTimeSpan[0];
var min = meetingsTimeSpan[0];
for (int i = 0; i < 10; i++)
{
    if (meetingsTimeSpan[i] > max)
    {
        max = meetingsTimeSpan[i];
    }
    if (meetingsTimeSpan[i] < min)
    {
        min = meetingsTimeSpan[i];
    }
}
Console.WriteLine($"\nThe longest meeting: {max}");
Console.WriteLine($"The shortest meeting: {min}");
TimeSpan m1;
DateTime m2;
for (int i = 0; i < 9; i++)
{
    for (int j = i + 1; j < 10; j++)
    {
        if ((meetingsDateTime[i].DayOfYear > meetingsDateTime[j].DayOfYear)
            || (meetingsDateTime[i].Day == meetingsDateTime[j].Day && meetingsDateTime[i].Hour > meetingsDateTime[j].Hour)
            || (meetingsDateTime[i].Hour == meetingsDateTime[j].Hour && meetingsDateTime[i].Minute > meetingsDateTime[j].Minute))
        {
            m1 = meetingsTimeSpan[i];
            m2 = meetingsDateTime[i];
            meetingsTimeSpan[i] = meetingsTimeSpan[j];
            meetingsDateTime[i] = meetingsDateTime[j];
            meetingsTimeSpan[j] = m1;
            meetingsDateTime[j] = m2;
        }
    }
}
TimeSpan max1 = meetingsDateTime[1] - (meetingsDateTime[0] + meetingsTimeSpan[0]);
TimeSpan min1 = meetingsDateTime[1] - (meetingsDateTime[0] + meetingsTimeSpan[0]);
var indexA = 0;
var indexB = 0;
for (int i = 0; i < 9; i++)
{
    if ((meetingsDateTime[i + 1] - (meetingsDateTime[i] + meetingsTimeSpan[i])) > max1)
    {
        max1 = meetingsDateTime[i + 1] - (meetingsDateTime[i] + meetingsTimeSpan[i]);
        indexA = i;
    }
    if ((meetingsDateTime[i + 1] - (meetingsDateTime[i] + meetingsTimeSpan[i])) < min1)
    {
        min1 = meetingsDateTime[i + 1] - (meetingsDateTime[i] + meetingsTimeSpan[i]);
        indexB = i;
    }
}
Console.WriteLine();
Console.WriteLine($"Max: {max1}\n{meetingsDateTime[indexA]} - {meetingsDateTime[indexA + 1]}");
Console.WriteLine($"Min: {min1}\n{meetingsDateTime[indexB]} - {meetingsDateTime[indexB + 1]}");