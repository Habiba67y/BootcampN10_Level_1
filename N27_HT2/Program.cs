using N27_HT2;
using System.Text.Json;

var VideoPosts = new List<VideoPost>
{
    new VideoPost("video1", "ajoyib video", 85, 5, Topics.Gaming),
    new VideoPost("video2", "yaxshi video", 75, 7, Topics.Business),
    new VideoPost("video3", "zo'r video", 100, 0, Topics.IT),
    new VideoPost("video4", "foydali video", 70, 2, Topics.IT),
    new VideoPost("video5", "tushunarsiz video", 60, 40, Topics.Gaming),
    new VideoPost("video6", "bema'ni video", 5, 100, Topics.Gaming),
    new VideoPost("video7", "kulgili video", 85, 10, Topics.Fun),
    new VideoPost("video8", "yana", 40, 40, Topics.Business),
    new VideoPost("video9", "qanaqadir", 50, 30, Topics.IT),
    new VideoPost("video10", "video", 60, 20, Topics.Fun),
};
Console.WriteLine("\nEng ko'p like olgani: ");
Console.WriteLine(VideoPosts.MaxBy(v => v.Likes));
Console.WriteLine("\nEng kam dislike olgani: ");
Console.WriteLine(VideoPosts.MinBy(v => v.DisLikes));
Console.WriteLine("\nLikelar o'rtachasi: ");
Console.WriteLine(VideoPosts.Average(v => v.Likes));
Console.WriteLine("\nBarcha videolardagi dislikelar soni: ");
Console.WriteLine(VideoPosts.Sum(v => v.DisLikes));
Console.WriteLine("\nTitle va description: ");
VideoPosts.Select(v => new { Title = v.Title, Description = v.Description}).ToList().ForEach(Console.WriteLine);
Console.WriteLine("\nTopiclar: ");
var topic = VideoPosts.Select(v => v.Topic).Distinct().ToList();
foreach(var item in topic)
    Console.WriteLine(item);
Console.WriteLine("\nTopic bo'yicha guruhlash: ");
var topics = VideoPosts.GroupBy(v => v.Topic).ToList();
Console.WriteLine(JsonSerializer.Serialize(topics));