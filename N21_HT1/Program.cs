using N21_HT1;

var list = new CustomList<int>();
list.Add(1);
list.Add(2);
list.Add(3);
var list1 = new List<int>();
list1.Add(4);
list1.Add(5);
Console.WriteLine(list.IndexOf(5));
list.AddRange(list1);
list.Insert(3, 2);
list.InsertRange(1, list1);
Console.WriteLine(list.Remove(1));
Console.WriteLine(list.RemoveAt(1));
var array = new int[list.Length()];
list.CopyTo(array);
var array1 = list.ToArray();
foreach (var item in array1)
{
    Console.WriteLine(item);
}

