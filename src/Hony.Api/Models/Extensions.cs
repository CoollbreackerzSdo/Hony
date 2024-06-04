using Hony.Api.Models.Token;

namespace Hony.Api.Models;

/// <summary>
/// Clase estática parcial que contiene métodos de extensión para diferentes tipos de entidades.
/// </summary>
public static partial class Extensions
{
    /// <summary>
    /// Convierte una entidad de token en un transporte de token.
    /// </summary>
    /// <param name="entity">La entidad de token a convertir.</param>
    /// <returns>Un transporte de token que contiene el token de acceso y el token de actualización.</returns>
    public static TokenTransport ToTransport(this TokenEntity entity)
        => new(entity.AccessToken, entity.RefreshToken);
}