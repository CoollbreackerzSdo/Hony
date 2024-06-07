namespace Hony.Api.Endpoints;

/// <summary>
/// Define una interfaz para mapear endpoints en la aplicación.
/// </summary>
public interface IEndpoint
{
    /// <summary>
    /// Mapea los endpoints en el constructor de rutas de endpoints.
    /// </summary>
    /// <param name="builder">El constructor de rutas de endpoints.</param>
    void Map(IEndpointRouteBuilder builder);
}