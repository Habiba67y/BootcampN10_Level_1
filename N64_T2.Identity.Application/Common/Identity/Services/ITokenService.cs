using N64_T2.Identity.DoMain.Entities;
using System.Linq.Expressions;

namespace N64_T2.Identity.Application.Common.Identity.Services;

public interface ITokenService
{
    IQueryable<Token> Get(Expression<Func<Token, bool>> predicate);

    ValueTask<Token?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    ValueTask<Token> CreateAsync(Token token, bool saveChanges = true, CancellationToken cancellationToken = default);
}
