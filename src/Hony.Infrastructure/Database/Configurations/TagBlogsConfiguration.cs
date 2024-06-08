using Hony.Domain.Models.Combinations;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hony.Infrastructure.Database.Configurations;

public sealed class TagBlogsConfiguration : IEntityTypeConfiguration<TagBlogsEntity>
{
    public void Configure(EntityTypeBuilder<TagBlogsEntity> builder)
    {
        
    }
}