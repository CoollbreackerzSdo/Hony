using Hony.Domain.Models.Aggregates;
using Hony.Domain.Models.Blogs;

namespace Hony.Domain.Models.Combinations;

/// <summary>
/// Representa la entidad de relación entre una categoría y un blog.
/// </summary>
public sealed class CategoryBlogsEntity : EntityBase
{
    /// <summary>
    /// Obtiene o establece el identificador de la categoría.
    /// </summary>
    public required EntityKey<Guid> CategoryId { get; init; }
    
    /// <summary>
    /// Obtiene o establece el identificador del blog.
    /// </summary>
    public required EntityKey<Guid> BlogId { get; init; }
    
    /// <summary>
    /// Obtiene o establece la entidad de la categoría.
    /// </summary>
    public CategoryEntity? Category { get; set; }
    
    /// <summary>
    /// Obtiene o establece la entidad del blog.
    /// </summary>
    public BlogEntity? Blog { get; set; }
}