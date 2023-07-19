using System.Collections.Immutable;

var sleepDays = new DateOnly[5]
{
     new DateOnly(2023, 07, 17),
     new DateOnly(2023, 07, 19),
     new DateOnly(2023, 07, 21),
     new DateOnly(2023, 07, 20),
     new DateOnly(2023, 07, 18),
};
var duration = new TimeSpan[5]
{
    TimeSpan.FromHours(8),
    TimeSpan.FromHours(7),
    TimeSpan.FromHours(6),
    TimeSpan.FromHours(5),
    TimeSpan.FromHours(9),
};
var awakingIndex = new float[5]{5, 1, 4, 2, 3};
DateOnly d;
TimeSpan t;
float f;
for (int i = 0; i < 4; i++)
{
    for (int j = i + 1; j < 5; j++)
    {
        if (sleepDays[i].Day > sleepDays[j].Day)
        {
            d = sleepDays[i];
            t = duration[i];
            f = awakingIndex[i];
            sleepDays[i] = sleepDays[j];
            duration[i] = duration[j];
            awakingIndex[i] = awakingIndex[j];
            sleepDays[j] = d;
            duration[j] = t;
            awakingIndex[j] = f;
        }
    }
}
var previousDayMissingSleep = new TimeSpan[5];
previousDayMissingSleep[0] = TimeSpan.FromHours(0);
for (int i = 1; i < 5; i++)
{
    previousDayMissingSleep[i] = TimeSpan.FromHours(8) - duration[i-1];
}
var sleepQuality = new double[5];
for (int i = 0; i < 5; i++)
{
    sleepQuality[i] = (duration[i].TotalHours - awakingIndex[i]) / (8 + previousDayMissingSleep[i].TotalHours) * 10;
    Console.WriteLine($"{sleepDays[i]} - {duration[i]} - {Convert.ToSingle(sleepQuality[i])}");
}
Console.WriteLine();
DateTime now = DateTime.Now;
DateOnly s;
for (int i = 0; i < 4; i++)
{
    for (int j = i + 1; j < 5; j++)
    {
        if (((now.Day - sleepDays[i].Day)<=0) &&((now.Day - sleepDays[j].Day) <= 0))
        {
            if ((now.Day - sleepDays[i].Day) > (now.Day - sleepDays[j].Day))
            {
                s = sleepDays[i];
                sleepDays[i] = sleepDays[j];
                sleepDays[j] = s;
            }
        }
        if (((now.Day - sleepDays[i].Day) >= 0) && ((now.Day - sleepDays[j].Day) >= 0))
        {
            if ((now.Day - sleepDays[i].Day) < (now.Day - sleepDays[j].Day))
            {
                s = sleepDays[i];
                sleepDays[i] = sleepDays[j];
                sleepDays[j] = s;
            }
        }
        if (((now.Day - sleepDays[i].Day) <= 0) && ((now.Day - sleepDays[j].Day) >= 0))
        {
            if ((sleepDays[i].Day - now.Day) < (now.Day - sleepDays[j].Day))
            {
                s = sleepDays[i];
                sleepDays[i] = sleepDays[j];
                sleepDays[j] = s;
            }
        }
        if (((now.Day - sleepDays[i].Day) >= 0) && ((now.Day - sleepDays[j].Day) <= 0))
        {
            if ((now.Day - sleepDays[i].Day) < (sleepDays[j].Day - now.Day))
            {
                s = sleepDays[i];
                sleepDays[i] = sleepDays[j];
                sleepDays[j] = s;
            }
        }

    }
    Console.WriteLine(sleepDays[i]);
}
Console.WriteLine(sleepDays[4]);
