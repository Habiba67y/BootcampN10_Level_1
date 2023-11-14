using Microsoft.EntityFrameworkCore;
using N71_HT1.Application.Common;
using N71_HT1.DoMain.Entities;
using N71_HT1.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace N71_HT1.Infrastructure.Common;

public class BlogService : IBlogService
{
    private readonly IBlogRepository _repository;

    public BlogService(IBlogRepository blogRepository)
    {
        _repository = blogRepository;
    }

    public IQueryable<Blog> Get(Expression<Func<Blog, bool>>? predicate = null, bool asNoTracking = false)
    => _repository.Get(predicate, asNoTracking).Include(blog => blog.Comments);

    public ValueTask<Blog?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellation = default)
    => _repository.GetByIdAsync(id, asNoTracking, cancellation);

    public ValueTask<IList<Blog>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellation = default)
    => _repository.GetByIdsAsync(ids, asNoTracking, cancellation);

    public ValueTask<Blog> CreateAsync(Blog blog, bool saveChanges = true, CancellationToken cancellation = default)
    {
        Validate(blog);

        return _repository.CreateAsync(blog, saveChanges, cancellation);
    }

    public async ValueTask<Blog> UpdateAsync(Blog blog, bool saveChanges = true, CancellationToken cancellation = default)
    {
        Validate(blog);

        var foundBlog = await _repository.UpdateAsync(blog, saveChanges, cancellation);

        foundBlog.Title = blog.Title;
        foundBlog.Description = blog.Description;

        return foundBlog;
    }

    public ValueTask<Blog?> DeleteAsync(Blog blog, bool saveChanges = true, CancellationToken cancellation = default)
    => _repository.DeleteAsync(blog, saveChanges, cancellation);

    public ValueTask<Blog?> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellation = default)
    => _repository.DeleteByIdAsync(id, saveChanges, cancellation);

    private void Validate(Blog blog)
    {
        if (string.IsNullOrWhiteSpace(blog.Title) || string.IsNullOrWhiteSpace(blog.Description))
            throw new InvalidDataException("Invalid blog");
    }
}
