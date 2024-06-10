namespace Hony.Application.Common.Models;

/// <summary>
/// Representa un comando de paginación con parámetros para saltar elementos, contar elementos y ordenar.
/// </summary>
/// <param name="Skip">El número de elementos a omitir.</param>
/// <param name="Count">El número de elementos a recuperar.</param>
/// <param name="OrderMode">El modo de ordenación de la página.</param>
public readonly record struct PaginationCommandHandler(int Skip, int Count, PageOrderMode OrderMode);
/// <summary>
/// Define los modos de ordenación para la paginación.
/// </summary>
public enum PageOrderMode
{
    /// <summary>
    /// Orden ascendente.
    /// </summary>
    Asc,

    /// <summary>
    /// Orden descendente.
    /// </summary>
    Desc
}