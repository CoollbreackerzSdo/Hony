using Hony.Application.Common.Externals.UnitOfWord;
using Hony.Infrastructure.Database;
using Hony.Infrastructure.Implementations.UnitOfWord;

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

        services.AddTransient<IUnitOfWord, UnitOfWord>();
        return services;
    }
}