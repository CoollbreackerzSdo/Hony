using System.Linq.Expressions;

using Hony.Api.Models.Token;

using Optional;

namespace Hony.Api.Services.Authentication.Jwt;

public interface IJwtManager
{
    Option<TResult> SelectAsOptionResult<TResult>(Expression<Func<TokenEntity, bool>> filter, Expression<Func<TokenEntity, TResult>> selector);
    void Add(TokenEntity model);
    Result<bool> IsExpired(Expression<Func<TokenEntity, bool>> filter);
}