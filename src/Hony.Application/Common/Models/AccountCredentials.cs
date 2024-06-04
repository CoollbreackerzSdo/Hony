namespace Hony.Application.Common.Models;

/// <summary>
/// Registro de estructura que representa las credenciales de una cuenta.
/// </summary>
public readonly record struct AccountCredentials(Guid Id, string UserName, string Email);