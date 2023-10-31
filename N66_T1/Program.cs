using Microsoft.Extensions.DependencyInjection;
using N66_T1.Models;
using N66_T1.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var services = new ServiceCollection();

services.AddDbContext<AppDbContext>();

var serviceProvider = services.BuildServiceProvider();

var appDbContext = serviceProvider.GetRequiredService<AppDbContext>();

if (!appDbContext.Authors.Any())
{
    appDbContext.Authors.AddRange
        (
           new Author
           {
               FirstName = "Falonchi",
               LastName = "Falonchiyev"
           },
           new Author
           {
               FirstName = "Palonchi",
               LastName = "Palonchiyev"
           }
        );

    var changedRowCount = await appDbContext.SaveChangesAsync();
}

if (!appDbContext.Books.Any())
{
    appDbContext.Books.AddRange
        (
        new Book 
        {
            Title = "Title1",
            Description = "description1",
            AuthorId = appDbContext.Authors.First().Id,
        },
        new Book 
        {
            Title = "Title2",
            Description = "description2",
            AuthorId = appDbContext.Authors.Skip(1).First().Id,
        }
        );
    var changedRowCount = await appDbContext.SaveChangesAsync();

}

var allBooks= await appDbContext.Books
    .Include(x => x.Author)
    .ToListAsync();

Console.WriteLine(JsonSerializer.Serialize(allBooks));