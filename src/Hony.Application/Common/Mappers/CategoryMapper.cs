using Hony.Application.Services.Handlers.Create;
using Hony.Domain.Models.Aggregates;

namespace Hony.Application.Common.Mappers;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByValue, EnumMappingIgnoreCase = true)]
internal static partial class CategoryMapper
{
    public static partial CategoryEntity Map(CreateCategoryCommandHandler command);
}