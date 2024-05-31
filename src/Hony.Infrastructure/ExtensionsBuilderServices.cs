using Hony.Infrastructure.Database;

using Microsoft.Extensions.DependencyInjection;

namespace Hony.Infrastructure;

public static class ExtensionsBuilderServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<HonyNpSqlContext>(config =>
        {
            config.UseNpgsql(Environment.GetEnvironmentVariable("POST_CONNECTION"), b => b.MigrationsAssembly("Hony.Api"));
        });
        return services;
    }
}