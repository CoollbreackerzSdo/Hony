using Hony.Domain.Models.Combinations;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hony.Infrastructure.Database.Configurations;

public sealed class CategoryBlogsConfiguration : EntityBaseConfiguration<CategoryBlogsEntity>
{
    public override void Configure(EntityTypeBuilder<CategoryBlogsEntity> builder)
    {
        base.Configure(builder);
    } 
}