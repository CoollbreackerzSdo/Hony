using Hony.Api.Models.Token;
using Hony.Application.Common.Models;

namespace Hony.Api.Services.Authentication.Jwt;

/// <summary>
/// Interfaz que define métodos para la gestión de servicios relacionados con tokens JWT.
/// </summary>
public interface IJwtServices
{
    /// <summary>
    /// Crea un nuevo token JWT asincrónicamente basado en las credenciales de la cuenta y el rol especificados.
    /// </summary>
    /// <param name="credentials">Las credenciales de la cuenta para las cuales se creará el token.</param>
    /// <param name="role">El rol asociado al token.</param>
    /// <param name="token">El token de cancelación opcional para la operación asincrónica.</param>
    /// <returns>Una tarea que representa la operación asincrónica. La tarea devuelve la entidad de token creada.</returns>
    Task<TokenEntity> CreateTokenAsync(AccountCredentials credentials, string role, CancellationToken token);
}