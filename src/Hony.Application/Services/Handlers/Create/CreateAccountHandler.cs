using Hony.Application.Common.Externals.UnitOfWord;
using Hony.Application.Common.Mappers;
using Hony.Application.Common.Models;
using Hony.Domain.Models.Account;

using Microsoft.AspNetCore.Identity;

namespace Hony.Application.Services.Handlers.Create;

internal class CreateAccountHandler(IUnitOfWord word, IPasswordHasher<AccountEntity> hasher) : IHandlerAsync<CreateAccountCommandHandler, AccountCredentials>
{
    [TranslateResultToActionResult]
    public async Task<Result<AccountCredentials>> HandleAsync(CreateAccountCommandHandler request, CancellationToken token = default)
    {
        if (word.AccountRepository.Any(x => x.UserName == request.UserName))
            return Result.Conflict("Nombre de usuario ya registrado");
        else if (word.AccountRepository.Any(x => x.Security.Email == request.Email))
            return Result.Conflict("Email ya registrado");
        //-
        var user = AccountMapper.ToAccount(request);
        user.Security.Password = hasher.HashPassword(user, user.Security.Password);
        word.AccountRepository.Add(user);
        await word.SaveChangesAsync(token);
        //-
        return AccountMapper.ToCredentials(user);
    }
}
public readonly record struct CreateAccountCommandHandler(string UserName, string Email, string Password, string? LastName = null, string? FirstName = null);