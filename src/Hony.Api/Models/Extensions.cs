using Hony.Api.Models.Token;

namespace Hony.Api.Models;

public static partial class Extensions
{
    public static TokenTransport ToTransport(this TokenEntity entity)
        => new(entity.AccessToken, entity.RefreshToken);
}