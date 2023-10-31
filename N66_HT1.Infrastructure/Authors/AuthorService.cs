using N66_HT1.Application.Authors;
using N66_HT1.DoMain.Entities;
using N66_HT1.Persistence.DataContexts;
using System.Linq.Expressions;

namespace N66_HT1.Infrastructure.Authors;

public class AuthorService : IAuthorService
{
    private readonly IDbContext _dbContext;

    public AuthorService(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<Author> Get(Expression<Func<Author, bool>> predicate)
    => _dbContext.Authors.Where(predicate.Compile()).AsQueryable();

    public ValueTask<ICollection<Author>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
    => new(Get(author => ids.Contains(author.Id)).ToList());

    public async ValueTask<Author?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    => await _dbContext.Authors.FindAsync(id, cancellationToken) ?? throw new ArgumentNullException("Author not found");

    public async ValueTask<Author> CreateAsync(Author author, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        Validate(author);

        await _dbContext.Authors.AddAsync(author);
        
        if(saveChanges) await _dbContext.SaveChangesAsync();

        return author;
    }
    
    public async ValueTask<Author> UpdateAsync(Author author, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        Validate(author);

        var foundAuthor = await GetByIdAsync(author.Id, cancellationToken);

        foundAuthor.FirstName = author.FirstName;
        foundAuthor.LastName = author.LastName;

        if (saveChanges) await _dbContext.SaveChangesAsync();

        return foundAuthor;
    }

    public async ValueTask<Author> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundAuthor = await GetByIdAsync(id, cancellationToken);

        _dbContext.Authors.Remove(foundAuthor);

        return foundAuthor;
    }

    public ValueTask<Author> DeleteAsync(Author author, bool saveChanges = true, CancellationToken cancellationToken = default)
    => DeleteAsync(author.Id, saveChanges, cancellationToken);

    private void Validate(Author author)
    {
        if (string.IsNullOrWhiteSpace(author.FirstName) || string.IsNullOrWhiteSpace(author.LastName))
            throw new InvalidDataException("Invalid FullName");
    }
}
