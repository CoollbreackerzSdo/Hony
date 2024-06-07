using Hony.Domain.Models.Blogs;
using Hony.Domain.Models.Twits;

namespace Hony.Domain.Models.Account;
/// <summary>
/// Modelo que representa una entidad de cuenta, derivada de <paramref name="EntityBase"/>
/// </summary>
public sealed class AccountEntity : EntityBase, IRegister
{
    /// <summary>
    /// Representa el nombre de usuario asociado a la cuenta. Este campo es obligatorio.
    /// </summary>
    public required string UserName { get; set; }

    /// <summary>
    /// Representa los detalles de seguridad de la cuenta. Este campo es obligatorio.
    /// </summary>
    public required AccountSecurity Security { get; init; }

    /// <summary>
    /// Representa los detalles opcionales de la cuenta. Este campo es obligatorio.
    /// </summary>
    public AccountDetail? Detail { get; init; }
    /// <summary>
    /// Obtiene o establece la colección de entidades <see cref="BlogEntity"/> asociadas.
    /// </summary>
    public ICollection<BlogEntity>? Blogs { get; set; }

    /// <summary>
    /// Obtiene o establece la colección de entidades <see cref="CommentEntity"/> asociadas.
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