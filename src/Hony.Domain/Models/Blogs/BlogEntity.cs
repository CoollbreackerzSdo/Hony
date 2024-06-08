using Hony.Domain.Models.Account;
using Hony.Domain.Models.Aggregates;
using Hony.Domain.Models.Combinations;

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
    /// Obtiene o establece el creador del blog asociado a la categoría.
    /// </summary>
    public AccountEntity? Creator { get; init; }

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
    /// Obtiene la hora en que la entidad fue registrada.
    /// </summary>
    public required TimeOnly RegisterTime { get; init; }
    /// <summary>
    /// Obtiene la fecha en que la entidad fue registrada.
    /// </summary>
    public required DateOnly RegisterDate { get; init; }
    /// <summary>
    /// Obtiene o establece la colección de de tags asociados con el blog.
    /// </summary>
    public ICollection<TagBlogEntity> Tags { get; set; } = new HashSet<TagBlogEntity>();
    /// <summary>
    /// Obtiene o establece la colección de comentarios asociados con el blog.
    /// </summary>
    public ICollection<CommentEntity> Comments { get; set; } = new HashSet<CommentEntity>();
    /// <summary>
    /// Obtiene o establece la colección de categorías asociados con el blog.
    /// </summary>
    public ICollection<CategoryBlogsEntity> Categories { get; set; } = new HashSet<CategoryBlogsEntity>();
}