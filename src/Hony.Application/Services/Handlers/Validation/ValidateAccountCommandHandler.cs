using Hony.Application.Common.Externals.UnitOfWord;
using Hony.Application.Common.Mappers;
using Hony.Application.Common.Models;
using Hony.Domain.Models.Account;

using Microsoft.AspNetCore.Identity;

namespace Hony.Application.Services.Handlers.Validation;


public class ValidateAccountHandler(IUnitOfWord word, IPasswordHasher<AccountEntity> hasher) : IHandler<ValidateAccountCommandHandler, AccountCredentials>
{
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
public readonly record struct ValidateAccountCommandHandler(string UserName, string Password);