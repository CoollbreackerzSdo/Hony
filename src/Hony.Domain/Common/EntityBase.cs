using System.Diagnostics.CodeAnalysis;

namespace Hony.Domain.Common;
/// <summary>
/// Clase base abstracta que proporciona las propiedades y el comportamiento básico para todas las entidades. 
/// Implementa <c>IEntity&lt;EntityKey&lt;Guid&gt;&gt;</c>, <c>IActive</c> e <c>IRegister</c>.
/// </summary>
public abstract class EntityBase : IEntity<EntityKey<Guid>>, IActive
{
    /// <summary>
    /// Obtiene el identificador único de la entidad.
    /// </summary>
    public required EntityKey<Guid> Id { get; init; }

    /// <summary>
    /// Obtiene o establece un valor que indica si la entidad está activa.
    /// </summary>
    public bool IsActive { get; set; } = true;
}