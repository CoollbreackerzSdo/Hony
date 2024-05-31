using Hony.Domain.Common;

namespace Hony.Domain.Models.Account;

public sealed class AccountEntity : EntityBase
{
    public required string UserName { get; set; }
    public required AccountSecurity Security { get; init; }
    public required AccountDetail Detail { get; init; }
}