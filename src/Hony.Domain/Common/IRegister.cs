namespace Hony.Domain.Common;

/// <summary>
/// Interfaz que define las propiedades para la fecha y hora de registro de una entidad.
/// </summary>
public interface IRegister
{
    /// <summary>
    /// Obtiene la hora en que la entidad fue registrada.
    /// </summary>
    TimeOnly RegisterTime { get; }

    /// <summary>
    /// Obtiene la fecha en que la entidad fue registrada.
    /// </summary>
    DateOnly RegisterDate { get; }
}