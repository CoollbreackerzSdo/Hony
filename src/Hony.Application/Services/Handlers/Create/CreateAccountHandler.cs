using Hony.Application.Common.Externals.UnitOfWord;
using Hony.Application.Common.Mappers;
using Hony.Application.Common.Models;
using Hony.Domain.Models.Account;

using Microsoft.AspNetCore.Identity;

namespace Hony.Application.Services.Handlers.Create;

/// <summary>
/// Clase interna que maneja el comando de creación de cuenta <see cref="CreateAccountCommandHandler"/>.
/// </summary>
internal sealed class CreateAccountHandler(IUnitOfWord word, IPasswordHasher<AccountEntity> hasher) : IHandlerAsync<CreateAccountCommandHandler, AccountCredentials>
{
    /// <summary>
    /// Maneja de forma asincrónica el comando de creación de cuenta.
    /// </summary>
    /// <param name="request">El comando de creación de cuenta a manejar.</param>
    /// <param name="token">Token de cancelación opcional para la operación asincrónica.</param>
    /// <returns>Un resultado que contiene las credenciales de la cuenta creada.</returns>
    [TranslateResultToActionResult]
    public async Task<Result<AccountCredentials>> HandleAsync(CreateAccountCommandHandler request, CancellationToken token = default)
    {
        if (word.AccountRepository.Any(x => x.UserName == request.UserName))
            return Result.Conflict("Nombre de usuario ya registrado");
        else if (word.AccountRepository.Any(x => x.Security.Email == request.Email))
            return Result.Conflict("Email ya registrado");

        var user = AccountMapper.Map(request);
        user.Security.Password = hasher.HashPassword(user, user.Security.Password);
        word.AccountRepository.Add(user);
        await word.SaveChangesAsync(token);

        return AccountMapper.ToCredentials(user);
    }
}

/// <summary>
/// Registro de estructura que representa el comando de creación de cuenta.
/// </summary>
public readonly record struct CreateAccountCommandHandler(string UserName, string Email, string Password, string? LastName = null, string? FirstName = null);