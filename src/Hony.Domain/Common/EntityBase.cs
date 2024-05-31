namespace Hony.Domain.Common;

public abstract class EntityBase : IEntity<EntityKey<Guid>>, IActive
{
    public EntityKey<Guid> Id { get; init; } = Guid.NewGuid();
    public bool IsActive { get; set; } = true;
}