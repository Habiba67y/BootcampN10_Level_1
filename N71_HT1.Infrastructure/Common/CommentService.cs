using N71_HT1.Application.Common;
using N71_HT1.DoMain.Entities;
using N71_HT1.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace N71_HT1.Infrastructure.Common;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _repository;

    public CommentService(ICommentRepository commentRepository)
    {
        _repository = commentRepository;
    }

    public IQueryable<Comment> Get(Expression<Func<Comment, bool>>? predicate = null, bool asNoTracking = false)
    => _repository.Get(predicate, asNoTracking);

    public ValueTask<Comment?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellation = default)
    => _repository.GetByIdAsync(id, asNoTracking, cancellation);

    public ValueTask<IList<Comment>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellation = default)
    => _repository.GetByIdsAsync(ids, asNoTracking, cancellation);

    public ValueTask<Comment> CreateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellation = default)
    {
        Validate(comment);

        return _repository.CreateAsync(comment, saveChanges, cancellation);
    }

    public async ValueTask<Comment> UpdateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellation = default)
    {
        Validate(comment);

        var foundComment = await _repository.UpdateAsync(comment, saveChanges, cancellation);

        foundComment.Commentary = comment.Commentary;

        return foundComment;
    }

    public ValueTask<Comment?> DeleteAsync(Comment comment, bool saveChanges = true, CancellationToken cancellation = default)
    => _repository.DeleteAsync(comment, saveChanges, cancellation);

    public ValueTask<Comment?> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellation = default)
    => _repository.DeleteByIdAsync(id, saveChanges, cancellation);

    private void Validate(Comment comment)
    {
        if (string.IsNullOrWhiteSpace(comment.Commentary))
            throw new InvalidDataException("Invalid commentary");
    }
}
