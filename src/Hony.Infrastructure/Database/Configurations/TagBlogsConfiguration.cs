using Hony.Domain.Models.Combinations;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hony.Infrastructure.Database.Configurations;

public sealed class TagBlogsConfiguration : EntityBaseConfiguration<TagBlogEntity>
{
    public override void Configure(EntityTypeBuilder<TagBlogEntity> builder)
    {
        base.Configure(builder);
    }
}