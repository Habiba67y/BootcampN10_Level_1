using N71_HT1.DoMain.Entities;

namespace N71_HT1.Application.Common;

public interface IBloggerManagementService
{
    ValueTask<IList<User>> GetPopularBloggers(bool asNoTracking = false, CancellationToken cancellation = default);
}
