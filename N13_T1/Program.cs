var ge = new GameEngine();
var oge = new GameEngine();
Console.WriteLine("\nGame engine:");
ge.Display();
Console.WriteLine("\nOptimized game engine:");
oge.Display();

public class GameEngine
{
    public List<Hero> heros = new List<Hero>();
    public GameEngine() 
    {
        heros.Add(new Hero("G'ishtmat"));
        heros.Add(new Hero("Toshmat"));
        heros.Add(new Hero("Eshmat"));
    }
    public void Display()
    {
        foreach (var hero in heros)
        {
            Console.WriteLine(hero.ToString());
        }
    }

}
public class OptimizedGameEngine: GameEngine 
{
    public OptimizedGameEngine()
    {
        heros.Add(new Hero("Surayyo"));
        heros.Add(new Hero("Muhayyo"));
        heros.Add(new Hero("Gulhayo"));
        Display();
    }
}
public class Hero
{
    public Guid Id = Guid.NewGuid();
    public string Name;
    public override string ToString()
    {
        return $"Id: {Id}\nName: {Name}";
    }
    public Hero(string name)
    {
        Name = name;
    }
}