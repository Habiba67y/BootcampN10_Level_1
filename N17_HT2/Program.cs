using N17_HT2;
//messagevalidator static classi nimaga kerakligini bilmadim, shunga yaratmadim
var c = new Chat();
c.Add("Hi everybody");
c.Add("Let's get started");
c.Add("We'll start the meeting in 10 minutes");

c.Update(c.Messages[2].Id, "Sorry guys, we are having technical issues, let's wait for another 10 minutes");
c.Update(c.Messages[2].Id, "I'm really sorry meeting is cancelled");
c.Display();