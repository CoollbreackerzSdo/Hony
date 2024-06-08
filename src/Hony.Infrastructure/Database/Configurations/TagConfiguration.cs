using Hony.Domain.Models.Aggregates;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hony.Infrastructure.Database.Configurations;

public sealed class TagConfiguration : EntityBaseConfiguration<TagEntity>
{
    public override void Configure(EntityTypeBuilder<TagEntity> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Name).HasMaxLength(100)
        .IsUnicode().IsRequired().HasColumnName("name");
        builder.HasMany(x => x.Blogs)
            .WithOne(x => x.Tag)
            .HasForeignKey(x => x.TagId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}