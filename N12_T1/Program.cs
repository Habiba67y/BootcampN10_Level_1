var c1 = new Car()
{
    Name = "Accord",
    Brand = "Honda"
};
var c2 = new Car()
{
    Name = "Camry",
    Brand = "Toyota"
};
var c3 = new Car()
{
    Name = "Civis",
    Brand = "Honda"
};
var c4 = new Car()
{
    Name = "Accord",
    Brand = "Honda"
};
var c5 = new Car()
{
    Name = "Elantra",
    Brand = "Hyundai"
};
var c6 = new Car()
{
    Name = "Accord",
    Brand = "Honda"
};
var c7 = new Car()
{
    Name = "Sonata",
    Brand = "Hyundai"
};
var c8 = new Car()
{
    Name = "Elantra",
    Brand = "Hyundai"
};
var c9 = new Car()
{
    Name = "Fusion",
    Brand = "Ford"
};
var c10 = new Car()
{
    Name = "Malibu",
    Brand = "Chevrolet"
};
List<Car> CarList = new List<Car>() { c1, c2, c3, c4, c5, c6, c7, c8, c9, c10 };
Dictionary<Car, int> cars = new Dictionary<Car, int>();
foreach (var car1 in CarList)
{
    var count = 0;
    foreach (var car2 in CarList)
    {
        if (car1.Equals(car2))
        {
            count++;
        }
    }
    if (!cars.ContainsKey(car1))
    {
        cars.Add(car1, count);
    }
}
foreach (var c in cars)
{
    if (c.Value != 1)
    {
        Console.WriteLine($"{c.Key.Name} {c.Key.Brand} - {c.Value}");
    }
}
public class Car
{
    public string Name { get; set; }
    public string Brand { get; set; }
    public override bool Equals(object? obj)
    {
        if (obj is Car car)
            return this.GetHashCode() == car.GetHashCode();
        

        return false;
    }
    public override int GetHashCode()
    {
        return Name.GetHashCode()
            + Brand.GetHashCode();
    }

}