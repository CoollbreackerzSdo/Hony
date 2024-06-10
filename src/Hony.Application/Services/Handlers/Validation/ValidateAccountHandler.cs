using Hony.Application.Common.Externals.UnitOfWord;
using Hony.Application.Common.Mappers;
using Hony.Application.Common.Models;
using Hony.Domain.Models.Account;

using Microsoft.AspNetCore.Identity;

namespace Hony.Application.Services.Handlers.Validation;


/// <summary>
/// Clase sellada interna que maneja el comando de validación de cuenta <see cref="ValidateAccountCommandHandler"/>.
/// </summary>
internal sealed class ValidateAccountHandler(IUnitOfWord word, IPasswordHasher<AccountEntity> hasher) : IHandler<ValidateAccountCommandHandler, AccountCredentials>
{
    /// <summary>
    /// Maneja el comando de validación de cuenta.
    /// </summary>
    /// <param name="command">El comando de validación de cuenta a manejar.</param>
    /// <returns>Un resultado que contiene las credenciales de la cuenta validada si la validación es exitosa.</returns>
    [TranslateResultToActionResult]
    public Result<AccountCredentials> Handle(ValidateAccountCommandHandler command)
    {
        var user = word.AccountRepository.SingleAsOption(x => x.UserName == command.UserName);
        return user.Match(
            some: value => hasher.VerifyHashedPassword(value!, value!.Security.Password, command.Password) switch
            {
                PasswordVerificationResult.Success => Result.Success(AccountMapper.ToCredentials(value)),
                _ => Result.Invalid()
            },
            none: () => Result.NotFound());
    }
}

/// <summary>
/// Registro de estructura que representa el comando de validación de cuenta.
/// </summary>
public readonly record struct ValidateAccountCommandHandler(string UserName, string Password);