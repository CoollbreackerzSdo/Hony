using Hony.Api.Endpoints;

using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Hony.Api;

public static class ExtensionBuilderServices
{
    public static IConfigurationBuilder AddEnvConfigurations(this ConfigurationManager builder)
    {
        builder.AddEnvironmentVariables("POST_CONNECTION");
        builder.AddEnvironmentVariables("MONG_CONNECTION");
        return builder;
    }
    public static IServiceCollection AddEndpoints(this IServiceCollection services)
    {
        services.TryAddEnumerable(typeof(Program).Assembly.DefinedTypes
            .Where(x => !x.IsInterface && !x.IsAbstract && x.IsAssignableTo(typeof(IEndpoint)))
            .Select(x => ServiceDescriptor.Transient(typeof(IEndpoint), x)));
        return services;
    }
    public static IEndpointRouteBuilder MapAppEndpoints(this WebApplication app)
    {
        foreach (var endpoint in app.Services.GetRequiredService<IEnumerable<IEndpoint>>())
        {
            endpoint.Map(app);
        }
        return app;
    }
}