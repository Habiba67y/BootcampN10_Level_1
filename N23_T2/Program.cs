﻿var numbers = new List<int>();
numbers.Add(3);
numbers.Add(9);
numbers.Add(-4);
numbers.Add(6);
numbers.Add(8);
numbers.Add(10);
Console.WriteLine("Hammasi musbatmi: "+numbers.All(n => n>0));
Console.WriteLine("Ichida toq sonmi: "+numbers.Any(n => n%2==1));
Console.WriteLine("Ichida 3 va 9 sonlari bormi: "+(numbers.Contains(3) && numbers.Contains(9)));