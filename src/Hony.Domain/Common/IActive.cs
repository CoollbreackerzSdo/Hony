namespace Hony.Domain.Common;

/// <summary>
/// Interfaz que define una propiedad para indicar si una entidad está activa.
/// </summary>
public interface IActive
{
    /// <summary>
    /// Obtiene un valor que indica si la entidad está activa.
    /// </summary>
    bool IsActive { get; }
}