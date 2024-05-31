using Hony.Application.Common.Externals.UnitOfWord;
using Hony.Domain.Models.Account;
using Hony.Infrastructure.Database;

namespace Hony.Infrastructure.Implementations.UnitOfWord;

internal class AccountRepository(HonyNpSqlContext context) : Repository<AccountEntity>(context) , IAccountRepository
{
    
}
