var ages = new int[]
{12,
15,
25,
12,
56,
13,
81,
55,
25,
12
};
for (int i = 0; i < ages.Length - 1; i++)
{
    for (int j = i + 1; j < ages.Length; j++)
    {
        if (ages[i] > ages[j])
        {
            var t = ages[i];
            ages[i] = ages[j];
            ages[j] = t;
        }
    }
}
int count = 1;
for (int i = 0; i < ages.Length - 1; i++)
{
    if (ages[i] == ages[i + 1])
    {
        count++;
    }
    else
    {
        if (count > 1)
        {
            Console.WriteLine($"{ages[i]} - {count}");
            count = 1;
        }
    }
}
//var a = new Dictionary<int, int>();
//for (int i = 0; i < ages.Length; i++)
//{
//    var count = 0;
//    for (int j = 0; j < ages.Length; j++)
//    {
//        if (ages[i] == ages[j])
//        {
//            count++;
//        }
//    }
//    if (!a.ContainsKey(ages[i]))
//    {
//        a.Add(ages[i], count);
//    }
//}
//foreach (var age in a)
//{
//    if (age.Value != 1)
//    {
//        Console.WriteLine($"{age.Key} - {age.Value}");
//    }
//}