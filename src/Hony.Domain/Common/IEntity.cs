namespace Hony.Domain.Common;
/// <summary>
/// Interfaz genérica para una entidad con un identificador de tipo <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">El tipo del identificador de la entidad. Debe ser no nulo y comparable.</typeparam>
public interface IEntity<T>
    where T : notnull, IComparable<T>
{
    /// <summary>
    /// Obtiene el identificador único de la entidad.
    /// </summary>
    T Id { get; }
}