using Hony.Application.Common.Externals.UnitOfWord;
using Hony.Infrastructure.Database;

namespace Hony.Infrastructure.Implementations.UnitOfWord;
internal class UnitOfWord : IUnitOfWord
{
    public UnitOfWord(HonyNpSqlContext context)
    {
        _context = context;
        AccountRepository = new AccountRepository(_context); 
    }
    public async Task SaveChangesAsync(CancellationToken token = default) 
        => await _context.SaveChangesAsync(token);
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            _disposedValue = true;
        }
    }
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
    private bool _disposedValue;
    private readonly HonyNpSqlContext _context;
    public IAccountRepository AccountRepository { get; }
}