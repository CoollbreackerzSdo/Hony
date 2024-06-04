using Hony.Api.Endpoints;
using Hony.Api.Middlewares.Errors;
using Hony.Api.Services.Authentication.Tokens;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection.Extensions;

using Serilog;

namespace Hony.Api;

public static class ExtensionBuilderServices
{
    public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services)
    {
        services.AddSingleton<JwtSettings>(_ => new()
        {
            Key = Environment.GetEnvironmentVariable("JWT_KEY")!,
        });
        services.AddAuthentication(config =>
        {
            config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            config.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
        });
        services.AddAuthorizationBuilder();
        return services;
    }
    public static IConfigurationBuilder AddEnvConfigurations(this ConfigurationManager builder)
    {
        builder.AddEnvironmentVariables("JWT_KEY");
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
    public static IServiceCollection AddSerilogConsole(this IServiceCollection services)
    {
        services.AddSerilog((sp, co) =>
        {
            co.WriteTo.Console();
        });
        return services;
    }
    public static IServiceCollection AddMiddlewares(this IServiceCollection services)
    {
        services.AddTransient<GlobalErrorMiddleware>();
        return services;
    }
    public static IApplicationBuilder MapMiddlewares(this WebApplication app)
    {
        app.UseMiddleware<GlobalErrorMiddleware>();
        return app;
    }
}