using Bogus;
using N71_HT1.DoMain.Entities;
using N71_HT1.Persistence.DataContexts;

namespace N71_HT1.Persistence.SeedData;

public static class EntityFakers
{
    public static Faker<User> GenerateUserFaker()
    {
        var random = new Random();

        return new Faker<User>()
            .RuleFor(user => user.FirstName, faker => faker.Person.FirstName)
            .RuleFor(user => user.LastName, faker => faker.Person.LastName)
            .RuleFor(user => user.Age, faker => random.Next(18, 45))
            .RuleFor(user => user.EmailAddress, faker => faker.Person.Email)
            .RuleFor(user => user.Password, faker => faker.Internet.Password(8));
    }

    public static Faker<Blog> GenerateBlogFaker(AppDbContext dbContext)
    {
        return new Faker<Blog>()
            .RuleFor(blog => blog.Title, faker => faker.Lorem.Word())
            .RuleFor(blog => blog.Description, faker => faker.Lorem.Text())
            .RuleFor(blog => blog.BloggerId, faker => faker.PickRandom(dbContext.Users.Select(user => user.Id).ToList()));
    }

    public static Faker<Comment> GenerateCommentFaker(AppDbContext dbContext)
    {
        return new Faker<Comment>()
            .RuleFor(comment => comment.Commentary, faker => faker.Lorem.Text())
            .RuleFor(comment => comment.BlogId, faker => faker.PickRandom(dbContext.Blogs.Select(blog => blog.Id).ToList()));
    }
}
