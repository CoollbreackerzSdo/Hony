using Hony.Domain.Models.Aggregates;
using Hony.Domain.Models.Blogs;

namespace Hony.Domain.Models.Combinations;

public sealed class CategoryBlogsEntity : EntityBase
{
    public required EntityKey<Guid> CategoryId { get; init; }
    public required EntityKey<Guid> BlogId { get; init; }
    public CategoryEntity? Category { get; set; }
    public BlogEntity? Blog { get; set; }
}