Animal d = new Dog();
Animal c = new Cat();
Animal r = new Rabbit();
d.FunFact();
c.FunFact();
r.FunFact();
public class Animal
{
    public virtual void FunFact()
    {
        Console.WriteLine("Bu shunchaki hayvon.");
    }
}
public class Dog : Animal
{
    public override void FunFact()
    {
        base.FunFact();
        Console.WriteLine("Va bu shunchaki kuchuk.");
    }
}
public class Cat : Animal
{
    public override void FunFact()
    {
        base.FunFact();
        Console.WriteLine("Va bu shunchaki mushuk.");
    }
}
public class Rabbit : Animal
{
    public override void FunFact()
    {
        base.FunFact();
        Console.WriteLine("Va bu shunchaki quyon.");
    }
}