using N64_T2.Identity.Application.Common.Identity.Services;
using N64_T2.Identity.DoMain.Entities;
using N64_T2.Identity.Persistence.DataContexts;
using System.Linq.Expressions;

namespace N64_T2.Identity.Infrastructure.Common.Identity.Services;

public class TokenService : ITokenService
{
    private readonly IDbContext _dbContext;

    public TokenService(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public IQueryable<Token> Get(Expression<Func<Token, bool>> predicate)
    => _dbContext.Tokens.Where(predicate.Compile()).AsQueryable();

    public async ValueTask<Token?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    => await _dbContext.Tokens.FindAsync(id, cancellationToken);

    public async ValueTask<Token> CreateAsync(Token token, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        Validate(token);

        await _dbContext.Tokens.AddAsync(token);

        if(saveChanges) await _dbContext.SaveChangesAsync();

        return token;
    }

    private void Validate(Token token)
    {
        if (string.IsNullOrWhiteSpace(token.Name))
            throw new InvalidDataException("Invalid token");
    }
}
