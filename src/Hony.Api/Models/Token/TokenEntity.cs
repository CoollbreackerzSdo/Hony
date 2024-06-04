using System.Diagnostics.CodeAnalysis;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Hony.Api.Models.Token;

/// <summary>
/// Clase que representa una entidad de token en la aplicación.
/// </summary>
public class TokenEntity
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="TokenEntity"/>.
    /// </summary>
    /// <param name="accessToken">El token de acceso.</param>
    /// <param name="refreshToken">El token de actualización.</param>
    /// <param name="accountId">El identificador de la cuenta asociada al token.</param>
    /// <param name="expirationToken">La fecha y hora de expiración del token.</param>
    private TokenEntity(string accessToken, string refreshToken, Guid accountId, DateTime expirationToken)
        => (AccessToken, RefreshToken, AccountId, ExpirationToken) = (accessToken, refreshToken, accountId, expirationToken);

    /// <summary>
    /// Crea una nueva instancia de la clase <see cref="TokenEntity"/>.
    /// </summary>
    /// <param name="accessToken">El token de acceso.</param>
    /// <param name="refreshToken">El token de actualización.</param>
    /// <param name="accountId">El identificador de la cuenta asociada al token.</param>
    /// <param name="expirationToken">La fecha y hora de expiración del token.</param>
    /// <returns>Una nueva instancia de <see cref="TokenEntity"/>.</returns>
    public static TokenEntity Create(string accessToken, string refreshToken, Guid accountId, DateTime expirationToken)
        => new(accessToken, refreshToken, accountId, expirationToken);

    /// <summary>
    /// Obtiene o establece el identificador único de la entidad de token.
    /// </summary>
    [BsonId]
    public ObjectId Id { get; init; } = ObjectId.GenerateNewId();

    /// <summary>
    /// Obtiene o establece el token de acceso.
    /// </summary>
    public string AccessToken { get; init; }

    /// <summary>
    /// Obtiene o establece el token de actualización.
    /// </summary>
    public string RefreshToken { get; init; }

    /// <summary>
    /// Obtiene o establece el identificador de la cuenta asociada al token.
    /// </summary>
    public Guid AccountId { get; init; }

    /// <summary>
    /// Obtiene o establece la fecha y hora de expiración del token.
    /// </summary>
    public DateTime ExpirationToken { get; init; }
}