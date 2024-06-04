namespace Hony.Api.Models.Token;
/// <summary>
/// Registro de solo lectura que representa un transporte de token.
/// Contiene propiedades para el token de acceso y el token de actualización.
/// </summary>
public readonly record struct TokenTransport(string AccessToken, string RefreshToken);