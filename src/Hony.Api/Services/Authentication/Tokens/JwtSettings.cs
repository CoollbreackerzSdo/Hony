namespace Hony.Api.Services.Authentication.Tokens;

public class JwtSettings
{
    public required string Key { get; init; }
    public DateTime ExpirationTick => DateTime.Now.AddDays(2);
}