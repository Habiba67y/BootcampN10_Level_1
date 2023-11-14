using Microsoft.EntityFrameworkCore;
using N71_HT1.Application.Common;
using N71_HT1.DoMain.Entities;

namespace N71_HT1.Infrastructure.Common;

public class BloggerManagementService : IBloggerManagementService
{
    private readonly IUserService _userService;

    public BloggerManagementService(IUserService userService)
    {
        _userService = userService;
    }

    public ValueTask<IList<User>> GetPopularBloggers(bool asNoTracking = false, CancellationToken cancellation = default)
    {
        var popularBloggers = _userService
            .Get()
            .Include(blogger => blogger.Blogs)
            .Where(blogger => blogger.Blogs
            .Where(blog => blog.Comments.Count() >= 20)
            .Count() >= 5)
            .OrderByDescending(blogger => blogger.Blogs.Count())
            .ToList();

        return new(popularBloggers);
    }
}
