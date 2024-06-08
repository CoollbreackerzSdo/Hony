using FluentValidation;

using Hony.Application.Common.Models;
using Hony.Application.Common.Validators;
using Hony.Application.Services.Handlers;
using Hony.Application.Services.Handlers.Create;
using Hony.Application.Services.Handlers.Validation;
using Hony.Domain.Models.Account;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Hony.Application;

/// <summary>
/// Clase estática que proporciona métodos de extensión para configurar servicios de aplicación.
/// </summary>
public static class ExtensionsBuilderServices
{
    /// <summary>
    /// Configura los servicios de aplicación añadiendo validadores, manejadores y servicios de hash.
    /// </summary>
    /// <param name="service">La colección de servicios a configurar.</param>
    /// <returns>La colección de servicios configurada.</returns>
    public static IServiceCollection ApplicationServices(this IServiceCollection service)
    {
        service.AddValidators();
        service.AddHandlers();
        service.AddHashes();
        return service;
    }

    /// <summary>
    /// Agrega validadores a la colección de servicios.
    /// </summary>
    /// <param name="services">La colección de servicios a la que se agregarán los validadores.</param>
    /// <returns>La colección de servicios con los validadores agregados.</returns>
    private static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddTransient<IValidator<CreateBlogCommandHandler>, CreateBlogValidator>();
        services.AddTransient<IValidator<ValidateAccountCommandHandler>, ValidateAccountValidator>();
        services.AddTransient<IValidator<CreateAccountCommandHandler>, CreateAccountValidator>();
        return services;
    }

    /// <summary>
    /// Agrega manejadores a la colección de servicios.
    /// </summary>
    /// <param name="services">La colección de servicios a la que se agregarán los manejadores.</param>
    /// <returns>La colección de servicios con los manejadores agregados.</returns>
    private static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddTransient<IHandler<ValidateAccountCommandHandler, AccountCredentials>, ValidateAccountHandler>();
        services.AddTransient<IHandlerAsync<CreateAccountCommandHandler, AccountCredentials>, CreateAccountHandler>();
        services.AddTransient<IHandlerAsync<(Guid, CreateBlogCommandHandler), BlogView>, CreateBlogHandler>();
        return services;
    }

    /// <summary>
    /// Agrega servicios de hash a la colección de servicios.
    /// </summary>
    /// <param name="services">La colección de servicios a la que se agregarán los servicios de hash.</param>
    /// <returns>La colección de servicios con los servicios de hash agregados.</returns>
    public static IServiceCollection AddHashes(this IServiceCollection services)
    {
        services.AddTransient<IPasswordHasher<AccountEntity>, PasswordHasher<AccountEntity>>();
        return services;
    }
}