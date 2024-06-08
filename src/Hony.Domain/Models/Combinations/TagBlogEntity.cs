using Hony.Domain.Models.Aggregates;
using Hony.Domain.Models.Blogs;

namespace Hony.Domain.Models.Combinations;

public sealed class TagBlogEntity : EntityBase
{
    public required EntityKey<Guid> TagId { get; init; }
    public required EntityKey<Guid> BlogId { get; init; }
    public BlogEntity? Blog { get; init; }
    public TagEntity? Tag { get; init; }
}