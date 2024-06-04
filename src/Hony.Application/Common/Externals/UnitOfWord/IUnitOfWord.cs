namespace Hony.Application.Common.Externals.UnitOfWord;

/// <summary>
/// Interfaz que define una unidad de trabajo para agrupar operaciones de repositorio y permitir su gestión transaccional.
/// Implementa <see cref="IDisposable"/>.
/// </summary>
public interface IUnitOfWord : IDisposable
{
    /// <summary>
    /// Guarda los cambios realizados en la unidad de trabajo de forma asincrónica.
    /// </summary>
    /// <param name="token">Token de cancelación opcional para la operación asincrónica.</param>
    /// <returns>Una tarea que representa la operación asincrónica de guardar los cambios.</returns>
    Task SaveChangesAsync(CancellationToken token = default);

    /// <summary>
    /// Obtiene el repositorio de cuentas.
    /// </summary>
    IAccountRepository AccountRepository { get; }

    /// <summary>
    /// Obtiene el repositorio de comentarios.
    /// </summary>
    ICommentRepository CommentRepository { get; }

    /// <summary>
    /// Obtiene el repositorio de blogs.
    /// </summary>
    IBlogRepository BlogRepository { get; }
}