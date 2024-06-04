namespace Hony.Api.Services.Authentication.Jwt;

/// <summary>
/// Clase que representa la configuración para la generación de tokens JWT.
/// </summary>
public class JwtSettings
{
    /// <summary>
    /// Obtiene o establece la clave secreta utilizada para firmar los tokens JWT.
    /// </summary>
    public required string Key { get; init; }

    /// <summary>
    /// Obtiene la fecha y hora de expiración predeterminada para los tokens JWT.
    /// Los tokens expirarán 2 días después de su creación.
    /// </summary>
    public DateTime TokenExpiration => DateTime.UtcNow.AddDays(2);
}