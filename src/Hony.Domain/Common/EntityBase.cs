namespace Hony.Domain.Common;
/// <summary>
/// Clase base abstracta que proporciona las propiedades y el comportamiento básico para todas las entidades. 
/// Implementa <c>IEntity&lt;EntityKey&lt;Guid&gt;&gt;</c>, <c>IActive</c> e <c>IRegister</c>.
/// </summary>
public abstract class EntityBase : IEntity<EntityKey<Guid>>, IActive, IRegister
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <c>EntityBase</c>.
    /// Establece la fecha y hora de registro a la hora actual en UTC.
    /// </summary>
    protected EntityBase()
    {
        var currentTime = DateTime.UtcNow;
        RegisterDate = DateOnly.FromDateTime(currentTime);
        RegisterTime = TimeOnly.FromDateTime(currentTime);
    }

    /// <summary>
    /// Obtiene el identificador único de la entidad.
    /// </summary>
    public EntityKey<Guid> Id { get; init; } = Guid.NewGuid();

    /// <summary>
    /// Obtiene o establece un valor que indica si la entidad está activa.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Obtiene la hora en que la entidad fue registrada.
    /// </summary>
    public TimeOnly RegisterTime { get; private init; }

    /// <summary>
    /// Obtiene la fecha en que la entidad fue registrada.
    /// </summary>
    public DateOnly RegisterDate { get; private init; }
}