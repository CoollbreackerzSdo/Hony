namespace Hony.Domain.Common;

public abstract class EntityBase : IEntity<EntityKey<Guid>>, IActive, IRegister
{
    protected EntityBase()
    {
        var currentTime = DateTime.UtcNow;
        RegisterDate = DateOnly.FromDateTime(currentTime);
        RegisterTime = TimeOnly.FromDateTime(currentTime);
    } 
    public EntityKey<Guid> Id { get; init; } = Guid.NewGuid();
    public bool IsActive { get; set; } = true;
    public TimeOnly RegisterTime { get; private init; }
    public DateOnly RegisterDate { get; private init; }
}