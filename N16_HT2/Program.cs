using N16_HT2;
//rosti bu misolni shartiga tushunmadim
Console.Write("Device name: ");
var shs = new SmartHomeService(Console.ReadLine());
shs.Activate();
Console.Write("Expected temperature: ");
shs.ExpectedTemperature = float.Parse(Console.ReadLine());
Console.Write("Current temperature: ");
var ct = float.Parse(Console.ReadLine());
while (shs.ExpectedTemperature != ct)
{
    shs.CurrentTemperature = ct;
    Console.Write("Current temperature: ");
    ct = float.Parse(Console.ReadLine());
}
shs.CurrentTemperature = ct;
shs.DisplayHomeTemperature();
