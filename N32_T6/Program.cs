using N32_T6;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

var blogService = new BlogService();
Console.WriteLine("Create: ");
try
{
    blogService.Create(new Blog(Console.ReadLine(), Console.ReadLine()));
}
catch (ValidationException v)
{
    Console.WriteLine(v.Message);
}
Console.WriteLine("Get:");
try
{
    blogService.Get(Guid.NewGuid());
}
catch (ArgumentOutOfRangeException a) 
{
    Console.WriteLine(a.Message);
}
Console.WriteLine("Update:");
try
{
    var blog = blogService.blogs[0];
    blog.Title = Console.ReadLine();
    blog.Body = Console.ReadLine();
    blogService.Update(blog);
}
catch (ValidationException v)
{
    Console.WriteLine(v.Message);
}
catch (InvalidOperationException i)
{
    Console.WriteLine(i.Message);
}
Console.WriteLine("Delete:");
try
{
    blogService.Delete(blogService.blogs[0].Id);
}
catch(ArgumentOutOfRangeException a)
{
    Console.WriteLine(a.Message);
}