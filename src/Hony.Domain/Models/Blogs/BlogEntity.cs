using Hony.Domain.Models.Account;
using Hony.Domain.Models.Twits;

namespace Hony.Domain.Models.Blogs;

public class BlogEntity : EntityBase
{
    public required EntityKey<Guid> CreatorId { get; init; }
    public required string Name { get; set; }
    public required BlogDetail Detail { get; init; }
    public virtual ICollection<CommentEntity>? Comments { get; set; }
}
