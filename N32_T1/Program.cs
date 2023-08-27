using N32_T1;

var obj1 = new ShortenedLink("qwerty12345", "qwerty");
var obj2 = new ShortenedLink("asdfg", "as");
var obj3 = new ShortenedLink("qwerty12345", "qwerty");
var obj4 = new ShortenedLink("asdfg", "as");
Console.WriteLine("obj1 equals obj2: "+ obj1.Equals(obj2));
Console.WriteLine("obj1 equals obj3: " +  obj1.Equals(obj3));
Console.WriteLine("obj2 equals obj3: " + obj2.Equals(obj3));
Console.WriteLine("obj2 equals obj4: " + obj2.Equals(obj4));
