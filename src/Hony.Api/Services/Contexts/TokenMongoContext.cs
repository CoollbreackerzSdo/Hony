using Hony.Api.Models.Token;

namespace Hony.Api.Services.Contexts;
/// <summary>
/// Clase que representa el contexto para la colección de tokens en MongoDB.
/// </summary>
public class TokenMongoContext
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="TokenMongoContext"/>.
    /// </summary>
    /// <param name="client">El cliente de MongoDB utilizado para acceder a la base de datos.</param>
    public TokenMongoContext(IMongoClient client)
    {
        _context = client.GetDatabase(HonyDatabaseName);
        Tokens = _context.GetCollection<TokenEntity>(nameof(Tokens));
    }
    /// <summary>
    /// Nombre de la base de datos de MongoDB para la aplicación Hony.
    /// </summary>
    public static readonly string HonyDatabaseName = "Hony";
    private readonly IMongoDatabase _context;
    /// <summary>
    /// Colección de tokens en el contexto de MongoDB.
    /// </summary>
    public readonly IMongoCollection<TokenEntity> Tokens;
}