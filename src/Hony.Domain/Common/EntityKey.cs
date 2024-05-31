namespace Hony.Domain.Common;

public readonly struct EntityKey<T>(T Value) : IComparable<EntityKey<T>>
    where T : notnull, IComparable<T>
{
    public readonly int CompareTo(EntityKey<T> other)
        => other is EntityKey<T> model ? Value.CompareTo(model.Value) : 0;
    public T Value { get; init; } = Value;
    public static implicit operator EntityKey<T>(T value)
        => new(value);
    public static implicit operator T(EntityKey<T> value)
        => value.Value;
    public static bool operator <(EntityKey<T> left, EntityKey<T> right)
        => left.CompareTo(right) < 0;
    public static bool operator <=(EntityKey<T> left, EntityKey<T> right)
        => left.CompareTo(right) <= 0;
    public static bool operator >(EntityKey<T> left, EntityKey<T> right)
        => left.CompareTo(right) > 0;
    public static bool operator >=(EntityKey<T> left, EntityKey<T> right)
        => left.CompareTo(right) >= 0;
}