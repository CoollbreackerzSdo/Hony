namespace Hony.Domain.Models.Aggregates;

public sealed class CategoryEntity : EntityBase
{
    public required string Name { get; init; }
}