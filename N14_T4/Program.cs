Console.WriteLine("To'g'ri to'rtburchak tomonlarni kiriting:");
Console.Write("a = ");
var a = int.Parse(Console.ReadLine());
Console.Write("b = ");
var b = int.Parse(Console.ReadLine());
var r = new Rectangle(a, b);
r.CalculateArea();
Console.WriteLine("Uchburchak balandligi va asosini kiriting:");
Console.Write("h = ");
var h = int.Parse(Console.ReadLine());
Console.Write("b = ");
var b1 = int.Parse(Console.ReadLine());
var t = new Triangle(h, b1);
t.CalculateArea();
Console.WriteLine("Doira radiusini kiriting:");
Console.Write("r = ");
var r1 = int.Parse(Console.ReadLine());
var c = new Circle(r1);
c.CalculateArea();
public class Shape
{
    public virtual void CalculateArea()
    {
        Console.WriteLine("Calculating area");
    }
}
public class Rectangle : Shape
{
    public float Tomon1;
    public float Tomon2;
    public Rectangle(float tomon1, float tomon2)
    {
        Tomon1 = tomon1;
        Tomon2 = tomon2;
    }
    public override void CalculateArea()
    {
        Console.WriteLine($"Area of rectangle: {Tomon1 * Tomon2}");
    }
}
public class Triangle : Shape
{
    public float balandlik;
    public float asos;
    public Triangle(float b, float h)
    {
        balandlik = h;
        asos = b;
    }
    public override void CalculateArea()
    {
        Console.WriteLine($"Area of triangle: {balandlik*asos*0.5}");
    }
}
public class Circle : Shape
{
    public float radius;
    public Circle(float r)
    {
        radius = r;
    }
    public override void CalculateArea() 
    {
        Console.WriteLine($"Area of circle: {3.14 * radius * radius}");
    }
}