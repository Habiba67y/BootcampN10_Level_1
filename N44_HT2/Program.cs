//deferred:
var numbers = new List<int>() { 1, 2, 3, 4, 5};
//1:
numbers.Select(x => x);
//2:
numbers.ForEach(Console.WriteLine);
//3
numbers.FirstOrDefault();

//immediate:
//1
numbers.ToList();
//2
numbers.ToArray();
//3
numbers.ToHashSet();

//mixed:
//1
numbers.Take(1);
//2
numbers.TakeLast(2);
//3
numbers.Skip(1);
