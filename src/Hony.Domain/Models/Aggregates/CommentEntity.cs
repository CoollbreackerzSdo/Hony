using Hony.Domain.Models.Account;
using Hony.Domain.Models.Blogs;

namespace Hony.Domain.Models.Aggregates;

/// <summary>
/// Representa una entidad de comentario dentro de un blog.
/// </summary>
public sealed class CommentEntity : EntityBase, IRegister
{
    /// <summary>
    /// Obtiene el identificador único de la entidad que creó el comentario.
    /// </summary>
    public required EntityKey<Guid> CreatorId { get; init; }
    /// <summary>
    /// Obtiene o establece el creador del blog asociado a la categoría.
    /// </summary>
    public AccountEntity? Creator { get; init; }

    /// Obtiene el identificador único de la entidad donde se hace referencia a este blog.
    /// </summary>
    public required EntityKey<Guid> BlogId { get; init; }
    /// <summary>
    /// Obtiene el identificador único del blog o elemento de contenido asociado con el comentario.
    /// </summary>
    public BlogEntity? Blog { get; init; }
    /// <summary>
    /// Obtiene o establece el contenido textual del comentario. Puede ser nulo.
    /// </summary>
    public required string? Message { get; set; }
    /// <summary>
    /// Obtiene la hora en que la entidad fue registrada.
    /// </summary>
    public required TimeOnly RegisterTime { get; init; }

    /// <summary>
    /// Obtiene la fecha en que la entidad fue registrada.
    /// </summary>
    public required DateOnly RegisterDate { get; init; }
}