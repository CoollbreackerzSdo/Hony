using Hony.Domain.Models.Aggregates;

namespace Hony.Application.Common.Models;

/// <summary>
/// Representa una vista de una etiqueta con un identificador, nombre, color y número de blogs habilitados.
/// </summary>
/// <param name="Id">El identificador único de la etiqueta.</param>
/// <param name="Name">El nombre de la etiqueta.</param>
/// <param name="Color">El color de la etiqueta representado como un OklhColor.</param>
/// <param name="EnableBlogs">El número de blogs habilitados asociados con la etiqueta.</param>
public readonly record struct TagView(Guid Id, string Name, OklhColor Color, int EnableBlogs);