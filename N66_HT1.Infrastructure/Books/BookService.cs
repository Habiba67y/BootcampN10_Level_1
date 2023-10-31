using Microsoft.EntityFrameworkCore;
using N66_HT1.Application.Books;
using N66_HT1.DoMain.Entities;
using N66_HT1.Persistence.DataContexts;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace N66_HT1.Infrastructure.Books;

public class BookService : IBookService
{
    private readonly IDbContext _dbContext;

    public BookService(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IQueryable<Book> Get(Expression<Func<Book, bool>> predicate)
    => _dbContext.Books.Include(book => book.Author).AsQueryable();

    public ValueTask<ICollection<Book>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
    => new(Get(book => ids.Contains(book.Id)).ToList());

    public ValueTask<Book?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    => new(Get(book => book.Id == id).FirstOrDefault() ?? throw new ArgumentNullException("Book not found"));

    public async ValueTask<Book> CreateAsync(Book book, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        Validate(book);

        await _dbContext.Books.AddAsync(book);

        if(saveChanges) await _dbContext.SaveChangesAsync();

        return book;
    }
    public async ValueTask<Book> UpdateAsync(Book book, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        Validate(book);

        var foundBook = await GetByIdAsync(book.Id, cancellationToken);

        foundBook.Title = book.Title;
        foundBook.Description = book.Description;

        if(saveChanges) await _dbContext.SaveChangesAsync();

        return foundBook;
    }


    public async ValueTask<Book> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundBook = await GetByIdAsync(id, cancellationToken);

        _dbContext.Books.Remove(foundBook);

        return foundBook;
    }

    public ValueTask<Book> DeleteAsync(Book book, bool saveChanges = true, CancellationToken cancellationToken = default)
    => DeleteAsync(book.Id, saveChanges, cancellationToken);

    private void Validate(Book book)
    {
        if (string.IsNullOrWhiteSpace(book.Title))
            throw new InvalidDataException("Invalid title");

        if (string.IsNullOrWhiteSpace(book.Description) || book.Description.Length < 7)
            throw new InvalidDataException("Invalid description");
    }
}
