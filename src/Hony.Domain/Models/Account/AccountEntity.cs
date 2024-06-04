using Hony.Domain.Common;

namespace Hony.Domain.Models.Account;
/// <summary>
/// Modelo que representa una entidad de cuenta, derivada de <paramref name="EntityBase"/>
/// </summary>
public sealed class AccountEntity : EntityBase
{
    /// <summary>
    /// Representa el nombre de usuario asociado a la cuenta. Este campo es obligatorio.
    /// </summary>
    public required string UserName { get; set; }

    /// <summary>
    /// Representa los detalles de seguridad de la cuenta. Este campo es obligatorio.
    /// </summary>
    public required AccountSecurity Security { get; init; }

    /// <summary>
    /// Representa los detalles opcionales de la cuenta. Este campo es obligatorio.
    /// </summary>
    public required AccountDetail Detail { get; init; }
}