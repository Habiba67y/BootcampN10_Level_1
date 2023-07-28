using System.Numerics;

//var p = new Planner();
//p.Add("Doing Homework", new TimeOnly(8,0,8));
//p.Add("Cleaning", new TimeOnly(13, 00, 0));
//p.Add("Cooking", new TimeOnly(16, 30, 0));
//p.Display();

var ep = new UltimatePlanner();
ep.Add("class", new TimeOnly(8, 00, 00));
ep.Add("ertangi kun", new DateTime(2023, 07, 28, 15, 30, 00));
ep.Add("meeting", new TimeOnly(13, 00, 00));
ep.Add("indingi kun", new DateTime(2023, 07, 29, 16, 00, 00));
ep.Add("sleeping", new TimeOnly(13, 00, 00));
ep.Add("indinni ertasi", new DateTime(2023, 07, 30, 13, 30, 00));
ep.Display();
public class Planner
{
    public Dictionary<string, TimeOnly> dailyPlans = new Dictionary<string, TimeOnly>();
    public virtual void Add(string plan, TimeOnly time)
    {
        dailyPlans.Add(plan, time);
    }
    public virtual void Display()
    {
        foreach (var planA in dailyPlans)
        {
            Console.WriteLine($"Event: {planA.Key} - time: {planA.Value}");
        }
    }
}
public class UltimatePlanner : Planner
{
    public Dictionary<string, DateTime> calendarPlans = new Dictionary<string, DateTime>();
    public override void Add(string plan, TimeOnly time)
    {
        var b = false;
        foreach (var planB in dailyPlans)
        {            
            if (time == planB.Value)
            {
                Console.WriteLine("You have conflict in daily plan:");
                Console.WriteLine($"{planB.Key} and {plan}\ntheir time: {planB.Value}  and {time}\n");
                b = true;
                break;
            }
        }
        if (b == false)
        {
            base.dailyPlans.Add(plan, time);
        }
    }
    public override void Display() 
    {
        foreach (var cp in calendarPlans)
        {
            Console.WriteLine($"Event: {cp.Key} - time: {cp.Value}");
        }
        foreach (var dp in dailyPlans)
        {
            Console.WriteLine($"Event: {dp.Key} - time: {dp.Value}");
        }
    }
    public void Add(string plan, DateTime time)
    {
        calendarPlans.Add(plan, time);
    }
}