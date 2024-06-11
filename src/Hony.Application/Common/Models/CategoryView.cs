using Hony.Domain.Models.Aggregates;

namespace Hony.Application.Common.Models;
/// <summary>
/// Representa una vista de una categoría con un identificador, nombre y color.
/// </summary>
/// <param name="Id">El identificador único de la categoría.</param>
/// <param name="Name">El nombre de la categoría.</param>
/// <param name="Color">El color de la categoría representado como un OklhColor.</param>
/// <param name="EnableBlogs">El número de blogs habilitados asociados con la categoría.</param>
public readonly record struct CategoryView(Guid Id, string Name, OklhColor Color, int EnableBlogs);