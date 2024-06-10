using Hony.Application.Services.Handlers.Create;
using Hony.Domain.Models.Aggregates;

namespace Hony.Application.Common.Mappers;

/// <summary>
/// Proporciona métodos para mapear entre diferentes tipos relacionados con la categoría.
/// </summary>
[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByValue, EnumMappingIgnoreCase = true)]
internal static partial class CategoryMapper
{
    /// <summary>
    /// Mapea un <see cref="CreateCategoryCommandHandler"/> a un <see cref="CategoryEntity"/>.
    /// </summary>
    /// <param name="command">El comando utilizado para crear la categoría.</param>
    /// <returns>Una entidad de categoría <see cref="CategoryEntity"/> mapeada a partir del comando.</returns>
    public static partial CategoryEntity Map(CreateCategoryCommandHandler command);
}