using System.Linq.Expressions;

using Hony.Api.Models.Token;
using Hony.Api.Services.Contexts;

namespace Hony.Api.Services.Authentication.Jwt;
/// <summary>
/// Clase que implementa la interfaz <see cref="IJwtManager"/> y proporciona métodos para la gestión de tokens JWT utilizando MongoDB como almacenamiento.
/// Inicializa una nueva instancia de la clase <see cref="JwtMongoManager"/>.
/// </summary>
public sealed class JwtMongoManager(TokenMongoContext context) : IJwtManager
{
    /// <inheritdoc/>
    public Option<TResult> SelectAsOptionResult<TResult>(Expression<Func<TokenEntity, bool>> filter, Expression<Func<TokenEntity, TResult>> selector)
        => context.Tokens.AsQueryable().Where(filter).Select(selector).SingleOrDefault() switch
        {
            TResult result => Option.Some(result),
            _ => Option.None<TResult>()
        };

    /// <inheritdoc/>
    public void Add(TokenEntity model)
        => context.Tokens.InsertOne(model);

    /// <inheritdoc/>
    public Result<bool> IsExpired(Expression<Func<TokenEntity, bool>> filter)
        => SelectAsOptionResult(filter, x => x.ExpirationToken)
            .Match(
                some: x => Result.Success(x > DateTime.UtcNow),
                none: () => Result.NotFound()
            );
    /// <inheritdoc/>
    public void Delete(Expression<Func<TokenEntity, bool>> filter)
        => context.Tokens.DeleteOne(filter);
    /// <inheritdoc/>
    public void DeleteAll(Expression<Func<TokenEntity, bool>> filter)
        => context.Tokens.DeleteMany(filter);
}