using N18_HT1;
//bu misolga ummuman tushunmadim, tushunganimcha qildim
var o = new OrderManagementService();
o.Add(100);
o.Add(154);
o.Add(2422);
o.Add(12);
o.Add(234);
Console.WriteLine("Max: " + o.Max());
Console.WriteLine("Min: " + o.Min());
Console.WriteLine("Sum: " + o.Sum());
o.Add(624);
o.Add(11);
Console.WriteLine();
Console.WriteLine("Max: " + o.Max());
Console.WriteLine("Min: " + o.Min());
Console.WriteLine("Sum: " + o.Sum());