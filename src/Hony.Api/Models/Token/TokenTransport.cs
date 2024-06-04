namespace Hony.Api.Models.Token;

public readonly record struct TokenTransport(string AccessToken, string RefreshToken);