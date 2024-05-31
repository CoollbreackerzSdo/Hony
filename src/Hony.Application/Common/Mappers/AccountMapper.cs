using Hony.Application.Common.Models;
using Hony.Application.Services.Handlers.Create;
using Hony.Domain.Models.Account;

using Riok.Mapperly.Abstractions;

namespace Hony.Application.Common.Mappers;
[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByValueCheckDefined, EnumMappingIgnoreCase = true)]
internal static partial class AccountMapper
{
    public static AccountEntity ToAccount(CreateAccountHandlerCommand command)
        => new()
        {
            UserName = command.UserName,
            Security = ToSecurity(command),
            Detail = ToDetail(command)
        };
    [MapProperty([nameof(AccountEntity.Security), nameof(AccountEntity.Security.Email)], [nameof(AccountCredentials.Email)])]
    public static partial AccountCredentials ToCredentials(AccountEntity account);
    private static partial AccountDetail ToDetail(CreateAccountHandlerCommand command);
    private static partial AccountSecurity ToSecurity(CreateAccountHandlerCommand command);
}