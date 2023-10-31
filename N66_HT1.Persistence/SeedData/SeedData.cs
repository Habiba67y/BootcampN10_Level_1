using N66_HT1.Persistence.DataContexts;

namespace N66_HT1.Persistence.SeedData;

public static class SeedData
{
    public static async ValueTask InitializeSeedDataAsync(this IDbContext context)
    {
        if (!context.Authors.Any())
            await context.AddAuthorsAsync(20);
        if (!context.Books.Any())
            await context.AddBooksAsync(30);

    }

    public static async ValueTask<int> AddAuthorsAsync(this IDbContext context, int count)
    {
        var faker = EntityFakers.GetAuthorFaker(context);
        var authors = faker.Generate(count);
        await context.Authors.AddRangeAsync(authors);

        var changedRowCount = await context.SaveChangesAsync();

        return changedRowCount;
    }

    public static async ValueTask<int> AddBooksAsync(this IDbContext context, int count)
    {
        var faker = EntityFakers.GetBookFaker(context);
        var books = faker.Generate(count);
        await context.Books.AddRangeAsync(books);

        var changedRowCount = await context.SaveChangesAsync();

        return changedRowCount;
    }
}
