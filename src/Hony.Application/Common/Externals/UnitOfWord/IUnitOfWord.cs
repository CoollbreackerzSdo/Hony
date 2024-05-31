namespace Hony.Application.Common.Externals.UnitOfWord;

public interface IUnitOfWord : IDisposable
{
    Task SaveChangesAsync(CancellationToken token = default);
    IAccountRepository AccountRepository { get; }
}