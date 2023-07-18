var names = new string[10]
{
    "John",
    "Stephan",
    "Toby",
    "Bob",
    "Andrew",
    "Austin",
    "Sam",
    "Kendall",
    "Kim",
    "Bella",
};
var balls = new int[10]
{
    100,
    80,
    60,
    85,
    65,
    50,
    75,
    95,
    70,
    90,
};
var b = 0;
var n = "";
for (int i = 0; i < 9; i++)
{
    for (int j = i + 1; j < 10; j++)
    {
        if (balls[i] < balls[j])
        {
            b = balls[i];
            n = names[i];
            balls[i] = balls[j];
            names[i] = names[j];
            balls[j] = b;
            names[j] = n;
        }
    }
}
Console.WriteLine($"Eng baland ball - {balls[0]} - {names[0]}");
Console.WriteLine($"Eng past ball - {balls[9]} - {names[9]}");
int s=0;
float a;
foreach(var ball in balls)
{
    s += ball;
}
a = s / 10;
Console.WriteLine($"O'rtacha ball - {a}");
for (int i=0; i<10; i++)
{
    if (balls[i] >= 90)
    {
        Console.WriteLine($"Ball: {balls[i]} -> {names[i]}-Top");
    }
    else if (balls[i] >= 80 && balls[i] < 90)
    {
        Console.WriteLine($"Ball: {balls[i]} -> {names[i]}-Good");
    }
    else if (balls[i] < 70)
    {
        Console.WriteLine($"Ball: {balls[i]} -> {names[i]}-Fail");
    }
    else
    {
        Console.WriteLine($"Ball: {balls[i]} -> {names[i]}");
    }
}