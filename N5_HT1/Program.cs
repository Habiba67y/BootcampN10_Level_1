var questions = new string[5]
{
    "What has a specification to execute only a true statement ?",
    "What statement is opposite to \"if\" ?",
    "What is alternative for \"else-if\" ?",
    "Which one is iteration statement ?",
    "Which one is selection statement ?",
};
var trueAnswers = new string[5]
{
    "if",
    "else",
    "switch case",
    "while",
    "if",
};
var falseAnswers = new string[5]
{
    "else",
    "switch case",
    "switch expression",
    "if",
    "for",
};
var userVariant = new string[5];
var rightVariant = new string[5];
int ball = 0, c = 0;
for (int i = 0; i < 5; i++)
{
    Random r = new Random();
    Console.WriteLine(questions[i]);
    Console.Write("A) ");
    if (r.Next(1, 3) == 1)
    {
        Console.WriteLine(trueAnswers[i]);
        rightVariant[i] = "A";
        c = 1;
    }
    else
    {
        Console.WriteLine(falseAnswers[i]);
        c = 2;
    }
    Console.Write("B) ");
    if (c == 1)
    {
        Console.WriteLine(falseAnswers[i]);
    }
    else
    {
        Console.WriteLine(trueAnswers[i]);
        rightVariant[i] = "B";
    }
    Console.Write("User: ");
    var a = Console.ReadLine();
    if (!String.IsNullOrEmpty(a))
    {
        if (a == "A" || a == "a")
        {
            userVariant[i] = "A";
        }
        if (a == "B" || a == "b")
        {
            userVariant[i] = "B";


        }
    }
}
var mistakes = new int[5];
var m = 0;
for (int j = 0; j < 5; j++)
{
    if (rightVariant[j] == userVariant[j])
    {
        ball++;
    }
    else
    {
        mistakes[m] = j;
        m++;
    }
}
Console.WriteLine("Ball: " + ball);
Console.WriteLine("\nInvalid answers:\n");
for (int k = 0; k < m; k++)
{
    Console.WriteLine("Question: " + questions[mistakes[k]]);
    Console.WriteLine("Answer: " + trueAnswers[mistakes[k]]);
}
