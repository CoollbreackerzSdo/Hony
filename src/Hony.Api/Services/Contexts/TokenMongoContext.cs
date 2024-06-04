using Hony.Api.Models.Token;

namespace Hony.Api.Services.Contexts;

public class TokenMongoContext
{
    public TokenMongoContext(IMongoClient client)
    {
        _context = client.GetDatabase(HonyDatabaseName);
        Tokens = _context.GetCollection<TokenEntity>(nameof(Tokens));
    }
    public static readonly string HonyDatabaseName = "Hony";
    private readonly IMongoDatabase _context;
    public readonly IMongoCollection<TokenEntity> Tokens;
}