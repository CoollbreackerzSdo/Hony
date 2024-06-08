using Hony.Application.Common.Externals.UnitOfWord;
using Hony.Domain.Models.Aggregates;
using Hony.Infrastructure.Database;

namespace Hony.Infrastructure.Implementations.UnitOfWord;
/// <summary>
/// Repositorio para la entidad <see cref="CommentEntity"/> que proporciona operaciones específicas para comentarios.
/// Hereda de <see cref="Repository{CommentEntity}"/> e implementa <see cref="ICommentRepository"/>.
/// Inicializa una nueva instancia de la clase <see cref="CommentRepository"/> con el contexto de base de datos especificado.
/// </summary>
/// <param name="context">El contexto de base de datos utilizado para las operaciones de datos.</param>
internal class CommentRepository(HonyAccountsNpSqlContext context) : Repository<CommentEntity>(context), ICommentRepository;