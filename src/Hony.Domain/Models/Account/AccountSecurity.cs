namespace Hony.Domain.Models.Account;

public sealed class AccountSecurity
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}