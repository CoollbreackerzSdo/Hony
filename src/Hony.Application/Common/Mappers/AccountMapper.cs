using Hony.Application.Common.Models;
using Hony.Application.Services.Handlers.Create;
using Hony.Domain.Models.Account;

using Riok.Mapperly.Abstractions;

namespace Hony.Application.Common.Mappers;
/// <summary>
/// Clase estática parcial que proporciona métodos para mapear entre diferentes tipos de entidades relacionadas con cuentas.
/// </summary>
[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByValueCheckDefined, EnumMappingIgnoreCase = true)]
internal static partial class AccountMapper
{
    /// <summary>
    /// Convierte un comando de creación de cuenta en una entidad de cuenta.
    /// </summary>
    /// <param name="command">El comando de creación de cuenta.</param>
    /// <returns>Una nueva instancia de <see cref="AccountEntity"/> que representa la cuenta creada.</returns>
    public static AccountEntity ToAccount(CreateAccountCommandHandler command)
        => new()
        {
            UserName = command.UserName,
            Security = ToSecurity(command),
            Detail = ToDetail(command)
        };

    /// <summary>
    /// Convierte una entidad de cuenta en credenciales de cuenta.
    /// </summary>
    /// <param name="account">La entidad de cuenta.</param>
    /// <returns>Una nueva instancia de <see cref="AccountCredentials"/> que representa las credenciales de la cuenta.</returns>
    [MapProperty([nameof(AccountEntity.Security), nameof(AccountEntity.Security.Email)], [nameof(AccountCredentials.Email)])]
    public static partial AccountCredentials ToCredentials(AccountEntity account);

    /// <summary>
    /// Convierte un comando de creación de cuenta en detalles de cuenta.
    /// </summary>
    /// <param name="command">El comando de creación de cuenta.</param>
    /// <returns>Una nueva instancia de <see cref="AccountDetail"/> que representa los detalles de la cuenta.</returns>
    private static partial AccountDetail ToDetail(CreateAccountCommandHandler command);

    /// <summary>
    /// Convierte un comando de creación de cuenta en detalles de seguridad de cuenta.
    /// </summary>
    /// <param name="command">El comando de creación de cuenta.</param>
    /// <returns>Una nueva instancia de <see cref="AccountSecurity"/> que representa los detalles de seguridad de la cuenta.</returns>
    private static partial AccountSecurity ToSecurity(CreateAccountCommandHandler command);
}