using Hony.Domain.Models.Account;
using Hony.Domain.Models.Twits;

namespace Hony.Domain.Models.Blogs;

/// <summary>
/// Modelo que representa una entidad de blog, heredando de <see cref="EntityBase"/>.
/// </summary>
public class BlogEntity : EntityBase
{
    /// <summary>
    /// Obtiene o establece el identificador del creador del blog.
    /// </summary>
    public required EntityKey<Guid> CreatorId { get; init; }

    /// <summary>
    /// Obtiene o establece el nombre del blog.
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// Obtiene o establece el contenido del blog.
    /// </summary>
    public required string Content { get; set; }

    /// <summary>
    /// Obtiene o establece los detalles adicionales del blog.
    /// </summary>
    public BlogDetail? Detail { get; init; }

    /// <summary>
    /// Obtiene o establece la colección de comentarios asociados con el blog.
    /// </summary>
    public virtual ICollection<CommentEntity>? Comments { get; set; }
}