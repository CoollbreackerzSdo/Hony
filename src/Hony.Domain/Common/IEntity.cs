namespace Hony.Domain.Common;

public interface IEntity<T>
    where T : notnull, IComparable<T>
{
    T Id { get; }
}