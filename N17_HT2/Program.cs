using N17_HT2;

var c = new Chat();
var m1 = c.Add("Hi everybody");
var m2 = c.Add("Let's get started");
var m3 = c.Add("We'll start the meeting in 10 minutes");

c.Update(m3, "Sorry guys, we are having technical issues, let's wait for another 10 minutes");
c.Update(m3, "I'm really sorry meeting is cancelled");
c.Display();