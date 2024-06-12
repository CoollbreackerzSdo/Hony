using Hony.Application.Common.Externals.UnitOfWord;
using Hony.Infrastructure.Database;
using Hony.Infrastructure.Implementations.UnitOfWord;

using Microsoft.Extensions.DependencyInjection;

namespace Hony.Infrastructure;

/// <summary>
/// Clase estática que proporciona métodos de extensión para configurar la infraestructura de la aplicación.
/// </summary>
public static class ExtensionsBuilderServices
{
    /// <summary>
    /// Agrega la infraestructura necesaria para la aplicación, incluido el contexto de la base de datos y la unidad de trabajo.
    /// </summary>
    /// <param name="services">La colección de servicios a configurar.</param>
    /// <returns>La colección de servicios configurada.</returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<HonyAccountsNpSqlContext>(config =>
        {
            config.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);
            config.UseNpgsql(Environment.GetEnvironmentVariable("POST_CONNECTION"), b => b.MigrationsAssembly("Hony.Api"));
        });

        services.AddTransient<IUnitOfWord, UnitOfWord>();
        return services;
    }
}