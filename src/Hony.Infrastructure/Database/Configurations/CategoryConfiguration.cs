using Hony.Domain.Models.Aggregates;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hony.Infrastructure.Database.Configurations;

public sealed class CategoryConfiguration : EntityBaseConfiguration<CategoryEntity>
{
    public override void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        base.Configure(builder);

        builder.HasMany(x => x.Blogs)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}