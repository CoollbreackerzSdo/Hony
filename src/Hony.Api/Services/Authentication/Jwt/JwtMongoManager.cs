using System.Linq.Expressions;

using Hony.Api.Models.Token;
using Hony.Api.Services.Contexts;

using Optional;

namespace Hony.Api.Services.Authentication.Jwt;

public sealed class JwtMongoManager(TokenMongoContext context) : IJwtManager
{
    public Option<TResult> SelectAsOptionResult<TResult>(Expression<Func<TokenEntity, bool>> filter, Expression<Func<TokenEntity, TResult>> selector)
    => context.Tokens.AsQueryable().Where(filter).Select(selector).SingleOrDefault() switch
    {
        TResult result => Option.Some(result),
        _ => Option.None<TResult>()
    };
    public void Add(TokenEntity model)
        => context.Tokens.InsertOne(model);
    public Result<bool> IsExpired(Expression<Func<TokenEntity, bool>> filter)
        => SelectAsOptionResult(filter, x => x.ExpirationToken)
            .Match(some: x => Result.Success(x > DateTime.UtcNow),
                    none: () => Result.NotFound());
}