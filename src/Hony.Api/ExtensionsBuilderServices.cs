using System.Text;

using Hony.Api.Endpoints;
using Hony.Api.Middlewares.Errors;
using Hony.Api.Services.Authentication.Jwt;
using Hony.Api.Services.Authentication.Providers;
using Hony.Api.Services.Contexts;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using Serilog;

namespace Hony.Api;

public static class ExtensionBuilderServices
{
    public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services)
    {
        services.AddAuthentication(config =>
        {
            config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            config.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(config =>
        {
            config.TokenValidationParameters = new()
            {
                ValidateActor = false,
                ValidateIssuer = false,
                ValidateLifetime = true,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_KEY")!))
            };
            config.Events = new()
            {
                OnMessageReceived = Middlewares.Events.JwtEvents.MessageReceivedToken
            };
        });
        services.AddAuthorizationBuilder()
            .AddPolicy(PoliciesProviderDefault.USER_VALORICE, config
                => config.AddAuthenticationSchemes([JwtBearerDefaults.AuthenticationScheme]).RequireRole([RolesProviderDefault.USER]).RequireAuthenticatedUser())
            .AddPolicy(PoliciesProviderDefault.MANAGES_VALORICE, config
                => config.AddAuthenticationSchemes([JwtBearerDefaults.AuthenticationScheme]).RequireRole([RolesProviderDefault.MANAGER]).RequireAuthenticatedUser());
        return services;
    }
    public static IServiceCollection AddJwtServices(this IServiceCollection services)
    {
        services.AddTransient(_ => Options.Create<JwtSettings>(new()
        {
            Key = Environment.GetEnvironmentVariable("JWT_KEY")!
        }));
        services.AddSingleton<IMongoClient, MongoClient>(_ => new MongoClient(Environment.GetEnvironmentVariable("MONG_CONNECTION")));
        services.AddScoped<TokenMongoContext>();
        services.AddScoped<IJwtManager, JwtMongoManager>();
        services.AddTransient<IJwtServices, JwtServicesDefault>();
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
    public static IServiceCollection AddSerilogServices(this IServiceCollection services)
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