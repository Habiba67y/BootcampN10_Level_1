using N19;

var p1 = new Person();
var p2 = new Person("Falonchi", "qayerdandir", 20);
var p3 = new Person(p1);
Console.WriteLine(p1.ToString());
Console.WriteLine(p2.ToString());
Console.WriteLine(p3.ToString());

var u1 = new User();
var u2 = new User("Falonchi", "qayerdandir", 20);
var u3 = new User(u2);
Console.WriteLine(u1.ToString());
Console.WriteLine(u2.ToString());
Console.WriteLine(u3.ToString());
var a = new int[] { 1, 2, 3 };
