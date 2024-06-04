namespace Hony.Domain.Models.Account;

/// <summary>
/// Modelo de seguridad de una cuenta.
/// </summary>
public sealed class AccountSecurity
{
    /// <summary>
    /// Representa el correo electrónico asociado a la cuenta. Este campo es obligatorio.
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// Representa la contraseña asociada a la cuenta. Este campo es obligatorio.
    /// </summary>
    public required string Password { get; set; }
}