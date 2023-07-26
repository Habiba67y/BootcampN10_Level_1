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
var a = new Dictionary<int, int>();
for (int i = 0; i < ages.Length; i++)
{
    var count = 0;
    for (int j = 0; j < ages.Length; j++)
    {
        if (ages[i] == ages[j])
        {
            count++;
        }
    }
    if (!a.ContainsKey(ages[i]))
    {
        a.Add(ages[i], count);
    }
}
foreach (var age in a)
{
    if (age.Value != 1)
    {
        Console.WriteLine($"{age.Key} - {age.Value}");
    }
}