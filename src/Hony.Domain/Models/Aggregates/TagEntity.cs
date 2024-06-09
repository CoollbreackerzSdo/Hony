using Hony.Domain.Models.Combinations;

namespace Hony.Domain.Models.Aggregates;

/// <summary>
/// Representa una etiqueta asociada con múltiples blogs.
/// </summary>
public sealed class TagEntity : EntityBase
{
    /// <summary>
    /// Obtiene o establece el nombre de la etiqueta.
    /// </summary>
    public required string Name { get; init; }
    /// <summary>
    /// Obtiene o establece el color de la etiqueta.
    /// </summary>
    public required OklhColor Color { get; set; }

    /// <summary>
    /// Obtiene o establece la colección de asociaciones entre etiquetas y blogs.
    /// </summary>
    public ICollection<TagBlogEntity> Blogs { get; set; } = new HashSet<TagBlogEntity>();
}