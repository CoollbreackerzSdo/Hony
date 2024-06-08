using Hony.Domain.Models.Aggregates;

namespace Hony.Application.Common.Externals.UnitOfWord;

/// <summary>
/// Interfaz que define el repositorio para la entidad <see cref="CommentEntity"/>.
/// Hereda de <see cref="IRepository{CommentEntity}"/>.
/// </summary>
public interface ICommentRepository : IRepository<CommentEntity>
{
}