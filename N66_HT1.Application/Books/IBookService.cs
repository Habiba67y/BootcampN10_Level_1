using N66_HT1.DoMain.Entities;
using System.Linq.Expressions;

namespace N66_HT1.Application.Books;

public interface IBookService
{
    IQueryable<Book> Get(Expression<Func<Book, bool>> predicate);

    ValueTask<ICollection<Book>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);

    ValueTask<Book?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    ValueTask<Book> CreateAsync(Book book, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Book> UpdateAsync(Book book, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Book> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Book> DeleteAsync(Book book, bool saveChanges = true, CancellationToken cancellationToken = default);
}
