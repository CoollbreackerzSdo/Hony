using Hony.Domain.Models.Aggregates;
using Hony.Domain.Models.Blogs;

namespace Hony.Domain.Models.Combinations;

/// <summary>
/// Representa la entidad de relación entre una etiqueta y un blog.
/// </summary>
public sealed class TagBlogEntity : EntityBase
{
    /// <summary>
    /// Obtiene o establece el identificador de la etiqueta.
    /// </summary>
    public required EntityKey<Guid> TagId { get; init; }
    
    /// <summary>
    /// Obtiene o establece el identificador del blog.
    /// </summary>
    public required EntityKey<Guid> BlogId { get; init; }
    
    /// <summary>
    /// Obtiene o establece la entidad del blog.
    /// </summary>
    public BlogEntity? Blog { get; init; }
    
    /// <summary>
    /// Obtiene o establece la entidad de la etiqueta.
    /// </summary>
    public TagEntity? Tag { get; init; }
}