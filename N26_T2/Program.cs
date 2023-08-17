using N26_T2;

var meetings = new List<Meeting>();
meetings.Add(new Meeting("qandaydir", new TimeSpan(0, 30, 00)));
meetings.Add(new Meeting("meeting", new TimeSpan(1, 30, 00)));
meetings.Add(new Meeting("bilmadim", new TimeSpan(2, 30, 00)));
meetings.Add(new Meeting("bir", new TimeSpan(1, 00, 00)));
meetings.Add(new Meeting("yana", new TimeSpan(2, 00, 00)));
var sumMeeting = new Meeting("", new TimeSpan(00, 00, 00));
for (int i = 0; i < meetings.Count - 1; i++)
{
    for (int j = i + 1; j < meetings.Count; j++)
    {
        if (meetings[i] > meetings[j])
        {
            var temp = meetings[i];
            meetings[i] = meetings[j];
            meetings[j] = temp;
        }
    }
}
foreach (var item in meetings)
{
    sumMeeting.Time = sumMeeting + item;
}
//sumMeeting.Time = sumMeeting + meetings[meetings.Count - 1];
meetings.ForEach(Console.WriteLine);
Console.WriteLine("\nBarcha meetinglar time i : "+sumMeeting.Time);