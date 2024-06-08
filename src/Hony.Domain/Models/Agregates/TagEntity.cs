namespace Hony.Domain.Models.Aggregates;

public sealed class TagEntity : EntityBase
{
    public required string Name { get; init; }
}