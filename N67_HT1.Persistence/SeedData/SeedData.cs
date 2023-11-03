using N67_HT1.Persistence.DataContext;
using N67_HT1.DoMain.Enums;

namespace N67_HT1.Persistence.SeedData;

public static class SeedData
{
    public static async ValueTask InitializeSeedData(this IDbContext dbContext)
    {
        if (!dbContext.Users.Any())
            dbContext.AddUsers(20);
        
        if(!dbContext.UsersSettings.Any())
            dbContext.AddUserSettings(20);

        if(!dbContext.Courses.Any())
            dbContext.AddCourses(10);

        if (!dbContext.StudentCourses.Any())
            dbContext.AddCourses(5);

        if (!dbContext.Locations.Where(location => location.Type == LocationType.Country).Any())
            dbContext.AddCountries(20);

        if (!dbContext.Locations.Where(location => location.Type == LocationType.City).Any())
            dbContext.AddCities(20);

    }

    private static async ValueTask<int> AddUsers(this IDbContext dbContext, int count)
    {
        var faker = EntityFakers.GenerateUserFaker();
        var users = faker.Generate(count);
        await dbContext.Users.AddRangeAsync(users);

        return await dbContext.SaveChangesAsync();
    }

    private static async ValueTask<int> AddUserSettings(this IDbContext dbContext, int count)
    {
        var faker = EntityFakers.GenerateUserSettingsFaker(dbContext);
        var usersSettings = faker.Generate(count);
        await dbContext.UsersSettings.AddRangeAsync(usersSettings);

        return await dbContext.SaveChangesAsync();
    }

    private static async ValueTask<int> AddCourses(this IDbContext dbContext, int count)
    {
        var faker = EntityFakers.GenerateCoursesFaker(dbContext);
        var courses = faker.Generate(count);
        await dbContext.Courses.AddRangeAsync(courses);

        return await dbContext.SaveChangesAsync();
    }

    private static async ValueTask<int> AddStudentCourses(this IDbContext dbContext, int count)
    {
        var faker = EntityFakers.GenerateStudentCoursesFaker(dbContext);
        var courses = faker.Generate(count);
        await dbContext.StudentCourses.AddRangeAsync(courses);

        return await dbContext.SaveChangesAsync();
    }

    private static async ValueTask<int> AddCountries(this IDbContext dbContext, int count)
    {
        var faker = EntityFakers.GenerateCountriesFaker(dbContext);
        var countries = faker.Generate(count);
        await dbContext.Locations.AddRangeAsync(countries);

        return await dbContext.SaveChangesAsync();
    }

    private static async ValueTask<int> AddCities(this IDbContext dbContext, int count)
    {
        var faker = EntityFakers.GenerateCitiesFaker(dbContext);
        var cities = faker.Generate(count);
        await dbContext.Locations.AddRangeAsync(cities);

        return await dbContext.SaveChangesAsync();
    }
}
