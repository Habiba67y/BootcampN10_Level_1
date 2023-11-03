using Bogus;
using Microsoft.EntityFrameworkCore;
using N67_HT1.DoMain.Entites;
using N67_HT1.DoMain.Enums;
using N67_HT1.Persistence.DataContext;

namespace N67_HT1.Persistence.SeedData;

public static class EntityFakers
{
    public static Faker<User> GenerateUserFaker()
    {
        var random = new Random();
        return new Faker<User>()
            .RuleFor(user => user.FirstName, faker => faker.Person.FirstName)
            .RuleFor(user => user.LastName, faker => faker.Person.LastName)
            .RuleFor(user => user.EmailAddress, faker => faker.Person.Email)
            .RuleFor(user => user.Role, (UserRole)random.Next(0, 2));
    }

    public static Faker<UserSettings> GenerateUserSettingsFaker(IDbContext dbContext)
    { 
        var users = new Stack<User>(dbContext.Users);
        return new Faker<UserSettings>()
            .RuleFor(userSettings => userSettings.UserId, users.Pop().Id);
    }

    public static Faker<Course> GenerateCoursesFaker(IDbContext dbContext)
    {
        return new Faker<Course>()
            .RuleFor(course => course.Name, faker => faker.Lorem.Word())
            .RuleFor(course => course.Description, faker => faker.Lorem.Text())
            .RuleFor(course => course.TeacherId, faker => faker.PickRandom(dbContext.Users.Where(user => user.Role == UserRole.Teacher).Select(teacher => teacher.Id).ToList()));
    }

    public static Faker<CourseStudent> GenerateStudentCoursesFaker(IDbContext dbContext)
    {
        return new Faker<CourseStudent>()
            .RuleFor(sc => sc.StudentId, faker => faker.PickRandom(dbContext.Users.Where(user => user.Role == UserRole.Student).Select(student => student.Id).ToList()))
            .RuleFor(sc => sc.CourseId, faker => faker.PickRandom(dbContext.Courses.Select(course => course.Id).ToList()));
    }

    public static Faker<Location> GenerateCountriesFaker(IDbContext dbContext)
    {
        return new Faker<Location>()
            .RuleFor(location => location.Name, faker => faker.Address.Country())
            .RuleFor(location => location.Type, LocationType.Country)
            .RuleFor(location => location.UserId, faker => faker.PickRandom(dbContext.Users.Select(user => user.Id).ToList()));
    }

    public static Faker<Location> GenerateCitiesFaker(IDbContext dbContext)
    {
        return new Faker<Location>()
            .RuleFor(location => location.Name, faker => faker.Address.City())
            .RuleFor(location => location.Type, LocationType.City)
            .RuleFor(location => location.ParentId, faker => faker.PickRandom(dbContext.Locations.Where(l => l.Type == LocationType.Country).Select(country => country.Id).ToList()))
            .RuleFor(location => location.UserId, faker => faker.PickRandom(dbContext.Users.Select(user => user.Id).ToList()));
    }
}
