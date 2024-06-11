using Hony.Domain.Common;

namespace Hony.Application.Common.Models;

/// <summary>
/// Registro de estructura que representa las credenciales de una cuenta.
/// </summary>
public readonly record struct AccountCredentials(Guid Id, string UserName, string Email);

public readonly record struct AccountComponentValidation(EntityKey<Guid> CreatorId, EntityKey<Guid> ComponentId);