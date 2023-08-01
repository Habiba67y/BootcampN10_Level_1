using N16_HT1;

var s = new Spaceship("spaceship", 200, 60, 32);
Console.WriteLine($"Name: {s.Name}\nFuel: {s.Fuel} l\nSpeed: {s.Speed} km/h\n");
s.Speed = 70;
s.Trajectory = 35;
Console.WriteLine($"Name: {s.Name}\nFuel: {s.Fuel}l\nSpeed: {s.Speed}km/h\n");
