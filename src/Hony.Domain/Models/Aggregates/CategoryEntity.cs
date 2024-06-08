using Hony.Domain.Models.Combinations;

namespace Hony.Domain.Models.Aggregates;

/// <summary>
/// Representa una categoría asociada con múltiples blogs.
/// </summary>
public sealed class CategoryEntity : EntityBase
{
    /// <summary>
    /// Obtiene o establece el nombre de la categoría.
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Obtiene o establece la colección de asociaciones entre categorías y blogs.
    /// </summary>
    public ICollection<CategoryBlogsEntity> Blogs { get; init; } = new HashSet<CategoryBlogsEntity>();
}