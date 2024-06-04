namespace Hony.Domain.Common;

/// <summary>
/// Estructura de registro que representa una clave de entidad genérica.
/// </summary>
/// <typeparam name="T">El tipo del valor de la clave. Debe ser no nulo y comparable.</typeparam>
public record struct EntityKey<T>(T Value) : IComparable<EntityKey<T>>
    where T : notnull, IComparable<T>
{
    /// <summary>
    /// Compara esta instancia de <see cref="EntityKey{T}"/> con otra para determinar el orden relativo.
    /// </summary>
    /// <param name="other">La otra instancia de <see cref="EntityKey{T}"/> a comparar.</param>
    /// <returns>Un valor que indica el orden relativo de las instancias comparadas.</returns>
    public readonly int CompareTo(EntityKey<T> other)
        => other is EntityKey<T> model ? Value.CompareTo(model.Value) : 0;

    /// <summary>
    /// Obtiene o establece el valor de la clave de entidad.
    /// </summary>
    public T Value { get; init; } = Value;

    /// <summary>
    /// Convierte implícitamente un valor de tipo <typeparamref name="T"/> a una <see cref="EntityKey{T}"/>.
    /// </summary>
    /// <param name="value">El valor de tipo <typeparamref name="T"/> a convertir.</param>
    /// <returns>Una nueva instancia de <see cref="EntityKey{T}"/>.</returns>
    public static implicit operator EntityKey<T>(T value)
        => new(value);

    /// <summary>
    /// Convierte implícitamente una <see cref="EntityKey{T}"/> a un valor de tipo <typeparamref name="T"/>.
    /// </summary>
    /// <param name="value">La instancia de <see cref="EntityKey{T}"/> a convertir.</param>
    /// <returns>El valor de tipo <typeparamref name="T"/>.</returns>
    public static implicit operator T(EntityKey<T> value)
        => value.Value;

    /// <summary>
    /// Determina si una instancia de <see cref="EntityKey{T}"/> es menor que otra.
    /// </summary>
    /// <param name="left">La primera instancia de <see cref="EntityKey{T}"/>.</param>
    /// <param name="right">La segunda instancia de <see cref="EntityKey{T}"/>.</param>
    /// <returns><c>true</c> si la primera instancia es menor que la segunda; de lo contrario, <c>false</c>.</returns>
    public static bool operator <(EntityKey<T> left, EntityKey<T> right)
        => left.CompareTo(right) < 0;

    /// <summary>
    /// Determina si una instancia de <see cref="EntityKey{T}"/> es menor o igual que otra.
    /// </summary>
    /// <param name="left">La primera instancia de <see cref="EntityKey{T}"/>.</param>
    /// <param name="right">La segunda instancia de <see cref="EntityKey{T}"/>.</param>
    /// <returns><c>true</c> si la primera instancia es menor o igual que la segunda; de lo contrario, <c>false</c>.</returns>
    public static bool operator <=(EntityKey<T> left, EntityKey<T> right)
        => left.CompareTo(right) <= 0;

    /// <summary>
    /// Determina si una instancia de <see cref="EntityKey{T}"/> es mayor que otra.
    /// </summary>
    /// <param name="left">La primera instancia de <see cref="EntityKey{T}"/>.</param>
    /// <param name="right">La segunda instancia de <see cref="EntityKey{T}"/>.</param>
    /// <returns><c>true</c> si la primera instancia es mayor que la segunda; de lo contrario, <c>false</c>.</returns>
    public static bool operator >(EntityKey<T> left, EntityKey<T> right)
        => left.CompareTo(right) > 0;

    /// <summary>
    /// Determina si una instancia de <see cref="EntityKey{T}"/> es mayor o igual que otra.
    /// </summary>
    /// <param name="left">La primera instancia de <see cref="EntityKey{T}"/>.</param>
    /// <param name="right">La segunda instancia de <see cref="EntityKey{T}"/>.</param>
    /// <returns><c>true</c> si la primera instancia es mayor o igual que la segunda; de lo contrario, <c>false</c>.</returns>
    public static bool operator >=(EntityKey<T> left, EntityKey<T> right)
        => left.CompareTo(right) >= 0;
}