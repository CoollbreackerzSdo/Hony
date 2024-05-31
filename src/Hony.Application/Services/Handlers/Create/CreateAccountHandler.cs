using Ardalis.Result;

using Hony.Application.Common.Externals.UnitOfWord;
using Hony.Application.Common.Mappers;
using Hony.Application.Common.Models;

namespace Hony.Application.Services.Handlers.Create;

internal class CreateAccountHandler(IUnitOfWord word) : IHandlerAsync<CreateAccountHandlerCommand, AccountCredentials>
{
    public async Task<Result<AccountCredentials>> HandleAsync(CreateAccountHandlerCommand request, CancellationToken token = default)
    {
        if (word.AccountRepository.Any(x => x.UserName == request.UserName))
            return Result.Conflict("Nombre de usuario ya registrado");
        else if (word.AccountRepository.Any(x => x.UserName == request.UserName))
            return Result.Conflict("Email ya registrado");
        //-
        var user = AccountMapper.ToAccount(request);
        word.AccountRepository.Add(user);
        await word.SaveChangesAsync(token);
        //-
        return AccountMapper.ToCredentials(user);
    }
}