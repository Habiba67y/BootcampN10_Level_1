using Bogus;
using N66_HT1.DoMain.Entities;
using N66_HT1.Persistence.DataContexts;
using System.Runtime.InteropServices;

namespace N66_HT1.Persistence.SeedData;

public static class EntityFakers
{
    public static Faker<Book> GetBookFaker(IDbContext context)
    {
        return new Faker<Book>()
            .RuleFor(book => book.Title, faker => faker.Lorem.Word())
            .RuleFor(book => book.Description, faker => faker.Lorem.Text())
            .RuleFor(book => book.AuthorId, faker => faker.PickRandom(context.Authors.Select(Author => Author.Id).ToList()));
    }
    public static Faker<Author> GetAuthorFaker(IDbContext context)
    {
        return new Faker<Author>()
            .RuleFor(author => author.FirstName, faker => faker.Person.FirstName)
            .RuleFor(author => author.LastName, faker => faker.Person.LastName);
    }
}
