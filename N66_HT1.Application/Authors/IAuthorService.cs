using N66_HT1.DoMain.Entities;
using System.Linq.Expressions;

namespace N66_HT1.Application.Authors;

public interface IAuthorService
{
    IQueryable<Author> Get(Expression<Func<Author, bool>> predicate);

    ValueTask<ICollection<Author>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);

    ValueTask<Author?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    ValueTask<Author> CreateAsync(Author author, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Author> UpdateAsync(Author author, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Author> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Author> DeleteAsync(Author author, bool saveChanges = true, CancellationToken cancellationToken = default);
}
