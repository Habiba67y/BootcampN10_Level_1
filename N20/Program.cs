using N20;

Console.WriteLine("\n№1:");
var b = new BubbleSort();
var array = new int[] { 1, 2, 10, 9, 3, 4, 8, 7, 5, 6 };
foreach (var item in b.bubbleSort(ref array))
{
    Console.WriteLine(item);
}

Console.WriteLine("\n№2:");
var p = new Perimetre();
p.GetArea(5, 6, out var P, out var S);
Console.WriteLine("Perimetre: "+P);
Console.WriteLine("Area: "+S);

Console.WriteLine("\n№3:");
var m = new MaxMin();
m.FindMaxMin(out var max, out var min, 11, 33, 99, 88);
Console.WriteLine("Max: " + max);
Console.WriteLine("Min: "+min);
Console.WriteLine("\n№4:");

var person1 = new Person("Habiba", 17); //<= optional
Console.WriteLine(person1.DisplayInfo());
var person2 = new Person(name: "Parizoda", age: 19); //<= named
Console.WriteLine(person2.DisplayInfo());