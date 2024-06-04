using System.Diagnostics.CodeAnalysis;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Hony.Api.Models.Token;

public class TokenEntity
{
    [SetsRequiredMembers]
    private TokenEntity(string accessToken, string refreshToken, Guid accountId, DateTime expirationToken)
        => (AccessToken, RefreshToken, AccountId, ExpirationToken) = (accessToken, refreshToken, accountId, expirationToken);
    public static TokenEntity Create(string accessToken, string refreshToken, Guid accountId, DateTime expirationToken)
        => new(accessToken, refreshToken, accountId, expirationToken);
    [BsonId]
    public ObjectId Id { get; init; } = ObjectId.GenerateNewId();
    public required string AccessToken { get; init; }
    public required string RefreshToken { get; init; }
    public required Guid AccountId { get; init; }
    public required DateTime ExpirationToken { get; init; }
}