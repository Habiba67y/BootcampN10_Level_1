using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

var users = Data.users;
var posts = Data.posts;
var ratings = Data.ratings;
var UserBlogs = users.GroupJoin(posts,
    u => u.Id,
    p => p.AuthorId,
    (users, posts) =>
    new
    {
        User = users,
        Posts = posts.Join(ratings,
         p => p.Id,
        r => r.PostId,
        (posts, ratings) =>
        new
        {
            Post = posts,
            Ratings = ratings
        })
    });
var UserPosts = users.GroupJoin(posts,
    u => u.Id,
    p => p.AuthorId,
    (users, posts) =>
    new
    {
        User = users,
        Posts = posts
    });

//1 - buni shartiga uncha tushunmadim, tahminan mana shunday qildim
//Console.WriteLine(JsonSerializer.Serialize(UserBlogs.Where(x => x.Posts.Count()>0 && x.Posts.FirstOrDefault(y => y.Ratings.IsLike) != null)));

//2
var BlogPostScores = users.GroupJoin(posts,
    u => u.Id,
    p => p.AuthorId,
    (users, posts) =>
    new
    {
        User = users,
        Posts = posts.Join(ratings,
        p => p.Id,
        r => r.PostId,
        (posts, ratings) =>
        new
        {
            Post = posts,
            Ratings = ratings
        }).Select(x => x.Ratings.IsLike ? +3 : -1)
    }).Select(x => new { User = x.User, Scores = x.Posts.Sum() });
//Console.WriteLine(JsonSerializer.Serialize(BlogPostScores));

//3
var maxPosts = UserPosts.MaxBy(x => x.Posts.Count());
var minPosts = UserPosts.MinBy(x => x.Posts.Count());
//Console.WriteLine("Max:\nUser: " + JsonSerializer.Serialize(maxPosts.User) + " Posts: " + maxPosts.Posts.Count());
//Console.WriteLine("Min:\nUser: " + JsonSerializer.Serialize(minPosts.User) + " Posts: " + minPosts.Posts.Count());

//4
var MostLikes = UserBlogs.MaxBy(x => x.Posts.Where(y => y.Ratings.IsLike).Count());
var MostDisLikes = UserBlogs.MaxBy(x => x.Posts.Where(y => y.Ratings.IsLike == false).Count());

//Console.WriteLine($"Most Likes\nUser: {JsonSerializer.Serialize(MostLikes.User)}\nAnd its likes: {MostLikes.Posts.Where(x => x.Ratings.IsLike).Count()}");
//Console.WriteLine($"Most DisLikes\nUser: {JsonSerializer.Serialize(MostDisLikes.User)}\nAnd its dislikes: {MostDisLikes.Posts.Where(x => x.Ratings.IsLike == false).Count()}");

//5
//var mostRating = UserBlogs.MaxBy(x => x.Posts.Count());
//var leastRating = UserBlogs.MinBy(x => x.Posts.Count());
//Console.WriteLine($"Eng ko'p rating berilgan: {JsonSerializer.Serialize(mostRating.User)} {mostRating.Posts.Count()}");
//Console.WriteLine($"Eng ko'p rating berilgan: {JsonSerializer.Serialize(leastRating.User)} {leastRating.Posts.Count()}");
