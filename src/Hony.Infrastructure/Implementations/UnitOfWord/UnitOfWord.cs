using Hony.Application.Common.Externals.UnitOfWord;
using Hony.Infrastructure.Database;

namespace Hony.Infrastructure.Implementations.UnitOfWord;
/// <summary>
/// Clase interna que representa una unidad de trabajo para operaciones relacionadas con la base de datos.
/// Implementa la interfaz <see cref="IUnitOfWord"/>.
/// </summary>
internal class UnitOfWord : IUnitOfWord
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="UnitOfWord"/>.
    /// </summary>
    /// <param name="context">El contexto de la base de datos utilizado por la unidad de trabajo.</param>
    public UnitOfWord(HonyAccountsNpSqlContext context)
    {
        _context = context;
        AccountRepository = new AccountRepository(_context);
        CommentRepository = new CommentRepository(_context);
        BlogRepository = new BlogRepository(_context);
        TagRepository = new TagRepository(_context);
    }
    /// <summary>
    /// Guarda todos los cambios realizados en la base de datos asincrónicamente.
    /// </summary>
    /// <param name="token">Token de cancelación opcional para la operación asincrónica.</param>
    /// <returns>Una tarea que representa la operación asincrónica.</returns>
    public async Task SaveChangesAsync(CancellationToken token = default)
        => await _context.SaveChangesAsync(token);
    /// <summary>
    /// Libera los recursos no administrados utilizados por la unidad de trabajo.
    /// </summary>
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
    /// <summary>
    /// Libera los recursos no administrados utilizados por la unidad de trabajo.
    /// </summary>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
    private bool _disposedValue;
    private readonly HonyAccountsNpSqlContext _context;
    /// <summary>
    /// Obtiene el repositorio de cuentas asociado con la unidad de trabajo.
    /// </summary>
    public IAccountRepository AccountRepository { get; }
    /// <summary>
    /// Obtiene el repositorio de comentarios.
    /// </summary>
    public ICommentRepository CommentRepository { get; }
    /// <summary>
    /// Obtiene el repositorio de blogs.
    /// </summary>
    public IBlogRepository BlogRepository { get; }
    /// <summary>
    /// Obtiene el repositorio de etiquetas.
    /// </summary>
    public ITagRepository TagRepository { get; }
}