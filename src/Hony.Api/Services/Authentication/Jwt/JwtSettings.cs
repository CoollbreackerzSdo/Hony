namespace Hony.Api.Services.Authentication.Jwt;

public class JwtSettings
{
    public required string Key { get; init; }
    public DateTime TokenExpiration => DateTime.UtcNow.AddDays(2);
}