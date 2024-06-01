using FluentValidation;

using Hony.Application.Common.Models;
using Hony.Application.Common.Validators;
using Hony.Application.Services.Handlers;
using Hony.Application.Services.Handlers.Create;

using Microsoft.Extensions.DependencyInjection;

namespace Hony.Application;

public static class ExtensionsBuilderServices
{
    public static IServiceCollection ApplicationServices(this IServiceCollection service)
    {
        service.AddValidators();
        service.AddHandlers();
        return service;
    }

    private static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddTransient<IValidator<CreateAccountHandlerCommand>, CreateAccountValidator>();
        return services;
    }

    private static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddTransient<IHandlerAsync<CreateAccountHandlerCommand, AccountCredentials>, CreateAccountHandler>();
        return services;
    }
}