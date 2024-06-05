using System.Linq.Expressions;

using Hony.Api.Models.Token;

using Optional;

namespace Hony.Api.Services.Authentication.Jwt;

/// <summary>
/// Interfaz que define métodos para la gestión de tokens JWT.
/// </summary>
public interface IJwtManager
{
    /// <summary>
    /// Selecciona un resultado opcionalmente según el filtro especificado y el selector de resultados.
    /// </summary>
    /// <typeparam name="TResult">El tipo de resultado seleccionado.</typeparam>
    /// <param name="filter">La condición para seleccionar la entidad de token.</param>
    /// <param name="selector">La función de selección de resultados.</param>
    /// <returns>Un resultado opcional que contiene el resultado seleccionado si se encuentra una coincidencia; de lo contrario, ninguno.</returns>
    Option<TResult> SelectAsOptionResult<TResult>(Expression<Func<TokenEntity, bool>> filter, Expression<Func<TokenEntity, TResult>> selector);

    /// <summary>
    /// Agrega una nueva entidad de token al gestor de tokens.
    /// </summary>
    /// <param name="model">La entidad de token a agregar.</param>
    void Add(TokenEntity model);

    /// <summary>
    /// Verifica si algún token seleccionado por el filtro proporcionado ha expirado.
    /// </summary>
    /// <param name="filter">La condición para seleccionar la entidad de token.</param>
    /// <returns>Un resultado que indica si algún token seleccionado ha expirado.</returns>
    Result<bool> IsExpired(Expression<Func<TokenEntity, bool>> filter);
    /// <summary>
    /// Elimina una entidad <see cref="TokenEntity"/> que cumpla con el filtro especificado.
    /// </summary>
    /// <param name="filter">Expresión lambda utilizada para filtrar la entidad a eliminar.</param>
    void Delete(Expression<Func<TokenEntity, bool>> filter);

    /// <summary>
    /// Elimina todas las entidades <see cref="TokenEntity"/> que cumplan con el filtro especificado.
    /// </summary>
    /// <param name="filter">Expresión lambda utilizada para filtrar las entidades a eliminar.</param>
    void DeleteAll(Expression<Func<TokenEntity, bool>> filter);
}