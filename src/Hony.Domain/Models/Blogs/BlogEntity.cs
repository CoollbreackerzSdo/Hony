using System.Diagnostics.CodeAnalysis;

using Hony.Domain.Models.Account;
using Hony.Domain.Models.Twits;

namespace Hony.Domain.Models.Blogs;

/// <summary>
/// Modelo que representa una entidad de blog, heredando de <see cref="EntityBase"/>.
/// </summary>
public sealed class BlogEntity : EntityBase, IRegister
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
    public ICollection<CommentEntity> Comments { get; set; } = new HashSet<CommentEntity>();

    /// <summary>
    /// Obtiene la hora en que la entidad fue registrada.
    /// </summary>
    public required TimeOnly RegisterTime { get; init; }

    /// <summary>
    /// Obtiene la fecha en que la entidad fue registrada.
    /// </summary>
    public required DateOnly RegisterDate { get; init; }
}