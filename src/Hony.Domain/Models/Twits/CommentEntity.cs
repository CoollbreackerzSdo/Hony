namespace Hony.Domain.Models.Twits;

/// <summary>
/// Representa una entidad de comentario dentro de un blog.
/// </summary>
public class CommentEntity : EntityBase
{
    /// <summary>
    /// Obtiene el identificador único de la entidad que creó el comentario.
    /// </summary>
    public required EntityKey<Guid> CreatorId { get; init; }

    /// <summary>
    /// Obtiene el identificador único del blog o elemento de contenido asociado con el comentario.
    /// </summary>
    public required EntityKey<Guid> BlogId { get; init; }

    /// <summary>
    /// Obtiene o establece el contenido textual del comentario. Puede ser nulo.
    /// </summary>
    public required string? Message { get; set; }
}