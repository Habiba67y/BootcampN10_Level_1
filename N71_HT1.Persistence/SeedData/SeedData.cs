using N71_HT1.Persistence.DataContexts;
using System.Data;
using System.Runtime.InteropServices;

namespace N71_HT1.Persistence.SeedData;

public static class SeedData
{
    public static async ValueTask InitializeSeedData(this AppDbContext dbContext)
    {
        if (!dbContext.Users.Any())
            await dbContext.AddUsers(10);

        if(!dbContext.Blogs.Any())
            await dbContext.AddBlogs(50);

        if(!dbContext.Comments.Any())
            await dbContext.AddComments(150);
    }

    private static async ValueTask<int> AddUsers(this AppDbContext dbContext, int count)
    {
        var faker = EntityFakers.GenerateUserFaker();
        var users = faker.Generate(count);
        await dbContext.Users.AddRangeAsync(users);

        return await dbContext.SaveChangesAsync();
    }

    private static async ValueTask<int> AddBlogs(this AppDbContext dbContext, int count)
    {
        var faker = EntityFakers.GenerateBlogFaker(dbContext);
        var blogs = faker.Generate(count);
        await dbContext.Blogs.AddRangeAsync(blogs);

        return await dbContext.SaveChangesAsync();
    }

    private static async ValueTask<int> AddComments(this AppDbContext dbContext, int count)
    {
        var faker = EntityFakers.GenerateCommentFaker(dbContext);
        var comments = faker.Generate(count);
        await dbContext.Comments.AddRangeAsync(comments);

        return await dbContext.SaveChangesAsync();
    }
}
