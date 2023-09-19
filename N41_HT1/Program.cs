using N41_HT1;

var threadSaveQueue = new ThreadSafeQueue<string>();
var enqueueTasks = new List<Task>()
{
    new (() => threadSaveQueue.Enqueue("Bir")),
    new (() => threadSaveQueue.Enqueue("Ikki")),
    new (() => threadSaveQueue.Enqueue("Uch")),
};
Parallel.ForEach(enqueueTasks, task => task.Start());
await Task.WhenAll(enqueueTasks);
foreach (var item in threadSaveQueue)
{
    Console.WriteLine(item);
}
var dequeueTasks = new List<Task>()
{
    new (() => threadSaveQueue.Dequeue()),
    new (() => threadSaveQueue.Dequeue()),
    new (() => threadSaveQueue.Dequeue()),
};
Console.WriteLine();
Parallel.ForEach(dequeueTasks, task => task.Start());
await Task.WhenAll(dequeueTasks);