using N52.Extentions;
using N52.Models;

var oldPost = new Post("title", "description", new List<Topic>() 
{
    new Topic(1, "topic1"),
    new Topic(2, "topic2"),
    new Topic(3, "topic3"),
});

var newPost = new Post("nom", "ta'rif", new List<Topic>()
{
    new Topic(2, "bo'lim2"),
    new Topic(3, "bo'lim3"),
    new Topic(1, "bo'lim1"),
});

var intersecteedList = oldPost.Topics.ZipIntersectBy(newPost.Topics, topic => topic.Id);

foreach (var (topic1, topic2) in intersecteedList)
{
    Console.WriteLine($"old: {topic1.Name}");
    Console.WriteLine($"new: {topic2.Name}\n");
}