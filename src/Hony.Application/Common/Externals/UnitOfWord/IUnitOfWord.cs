namespace Hony.Application.Common.Externals.UnitOfWord;

public interface IUnitOfWord : IDisposable
{
    void SaveChangesAsync(CancellationToken token = default);
    IAccountRepository AccountRepository { get; }
}