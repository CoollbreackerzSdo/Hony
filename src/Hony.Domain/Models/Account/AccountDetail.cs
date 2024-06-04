using System.Diagnostics.CodeAnalysis;

namespace Hony.Domain.Models.Account;
/// <summary>
/// Modelo base de detalles opcionales de una cuenta.
/// </summary>
public sealed class AccountDetail
{
    /// <summary>
    /// Representa el apellido del individuo de la cuenta.
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Representa el primer nombre del individuo de la cuenta.
    /// </summary>
    public string? FirstName { get; set; }
}