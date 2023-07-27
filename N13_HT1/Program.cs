using System.Collections.Concurrent;

var s = new Sparrow();
var t = new Tiger();
var g = new GreatWhiteShark();
//s.MakeSound();
//s.Fly();
//t.MakeSound();
//t.Run();
//g.MakeSound();
//g.Swim();
public class Sparrow : Bird
{
    public Sparrow() 
    {
 //       MakeSound();
        Fly();
    }
}
public class Tiger : Mammal
{
    public Tiger()
    {
 //       MakeSound();
        Run();
    }
}
public class GreatWhiteShark : Fish
{
    public GreatWhiteShark()
    {
 //       MakeSound();
        Swim();
    }
}
public class Bird : Animal
{
    public void Fly()
    {
        Console.WriteLine("Fly");
    }
    public Bird()
    {
        MakeSound();
    }

}
public class Mammal : Animal
{
    public void Run()
    {
        Console.WriteLine("Run");
    }
    public Mammal()
    {
        MakeSound();
    }

}
public class Fish : Animal
{
    public void Swim()
    {
        Console.WriteLine("Swim");
    }
    public Fish()
    {
        MakeSound();
    }

}
public class Animal
{
    public void MakeSound()
    {
        Console.WriteLine("...");
    }
}