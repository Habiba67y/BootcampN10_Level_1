var list  = new List<int>();
for (int i = 1; i < 101; i++)
{
    list.Add(i);
}
var primes = list.Where(number =>
        Enumerable.Range(2, (int)Math.Sqrt(number) - 1)
        .All(divisor => number % divisor != 0)).ToList().OrderByDescending(i => i).ToList();
primes.ForEach(Console.WriteLine);