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

public static class ExtensionsBuilderServices
{
    public static IServiceCollection ApplicationServices(this IServiceCollection service)
    {
        service.AddValidators();
        service.AddHandlers();
        service.AddHashes();
        return service;
    }

    private static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddTransient<IValidator<CreateAccountCommandHandler>, CreateAccountValidator>();
        return services;
    }

    private static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddTransient<IHandler<ValidateAccountCommandHandler, AccountCredentials>, ValidateAccountHandler>();
        services.AddTransient<IHandlerAsync<CreateAccountCommandHandler, AccountCredentials>, CreateAccountHandler>();
        return services;
    }

    public static IServiceCollection AddHashes(this IServiceCollection services)
    {
        services.AddTransient<IPasswordHasher<AccountEntity>, PasswordHasher<AccountEntity>>();
        return services;
    }
}