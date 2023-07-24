//using System.Diagnostics;

//Console.Write("Narxlar: ");
//var narxlar = Console.ReadLine();
//var n = narxlar.Split();
//var dict = n.GroupBy(x => x).ToDictionary(y => y.Key, z => z.Count());
//var total = 0;
//Stopwatch stopWatch = new Stopwatch();
//stopWatch.Start();
//foreach (var d in dict)
//{
//    var price = Convert.ToInt32(d.Key);
//    var c = d.Value - (d.Value / 3);
//    total += price * c;
//}
//stopWatch.Stop();
//TimeSpan ts = stopWatch.Elapsed;
//Console.WriteLine($"{total} {ts}");

////№1
//using System.Diagnostics;
//using System.Numerics;
//string s="";
//Console.Write("Yoshingizni kiriting: ");
//try
//{
//    var age = Convert.ToInt32(Console.ReadLine());
//    s = age switch
//    {
//        < 18 => throw new ArgumentOutOfRangeException("Sorry, you're too young!"),
//        > 90 => throw new ArgumentOutOfRangeException("Sorry, you're too old!"),
//        _ => "Valid age!"
//    };
//}
//catch (ArgumentOutOfRangeException argumentOutOfRangeException)
//{
//    Console.WriteLine(argumentOutOfRangeException);
//}
//catch (Exception exception)
//{
//    Console.WriteLine(exception);
//}
//finally
//{
//    Console.WriteLine(s);
//}

//№2
Console.WriteLine("Random sonni toping: ");
Random r = new Random();
var guessingNumber = r.Next(1, 10);
while (true)
{
    try
    {
        Console.Write("Son kiriting: ");
        var number = Console.ReadLine();
        if (int.TryParse(number, out var n))
        {
            if (n != guessingNumber)
            {
                throw new ArgumentOutOfRangeException("You couldn't guess it");
            }
        
        }
        else
        {
            throw new FormatException("Not a number!");
        }
        Console.WriteLine("Congratulations! You guessed it!!!");
        break;
    }
    catch (ArgumentOutOfRangeException argumentOutOfRangeException)
    {
        Console.WriteLine(argumentOutOfRangeException);
    }
    catch (FormatException formatException)
    {
        Console.WriteLine(formatException);
    }
    catch (Exception exception)
    { 
        Console.WriteLine(exception);
    }
}