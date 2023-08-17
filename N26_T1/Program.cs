using N26_T1;

var priorityQueue = new PriorityQueue<ITaskEvent>();

priorityQueue.Enqueue(new TaskItem("Course", "Finish udemy course", 8));
priorityQueue.Enqueue(new TaskItem("Homework", "Do homework", 1));
priorityQueue.Enqueue(new TaskItem("Toqqa", "G`ishtmatni ko'rishga", 5));
priorityQueue.Enqueue(new TaskItem("Turnir", "Join to Internal Pointer Cybpersport team", 6));

priorityQueue.Enqueue(new EventItem("Meeting with clients", DateTime.Now.AddHours(1)));
priorityQueue.Enqueue(new EventItem("Najot Quiz", DateTime.Now.AddHours(2)));
priorityQueue.Enqueue(new EventItem("Sharpist Hackathon", DateTime.Now.AddDays(2)));
priorityQueue.Enqueue(new EventItem("Exam", DateTime.Now.AddHours(5)));

priorityQueue.Dequeue();
foreach (var item in priorityQueue)
{
    item.Display();
}
