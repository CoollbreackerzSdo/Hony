using Hony.Domain.Models.Twits;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hony.Infrastructure.Database.Configurations;

public sealed class CommentConfiguration : EntityBaseConfiguration<CommentEntity>
{
    public override void Configure(EntityTypeBuilder<CommentEntity> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Message).IsRequired().HasMaxLength(5_000);
    }
}