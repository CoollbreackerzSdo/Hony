using Hony.Domain.Models.Account;
using Hony.Domain.Models.Blogs;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Hony.Infrastructure.Database.Configurations;

public sealed class BlogConfiguration : EntityBaseConfiguration<BlogEntity>
{
    public override void Configure(EntityTypeBuilder<BlogEntity> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(1_000).HasColumnName("name");
        builder.Property(x => x.CreatorId)
            .IsRequired();
        builder.OwnsOne(x => x.Detail,navigation => 
        {
            navigation.Property(x => x.ReTwits).HasDefaultValue(0).HasColumnName("re_twits");
        });
        builder.HasMany(x => x.Comments)
            .WithOne()
            .HasForeignKey(x => x.BlogId)
            .IsRequired()
            .OnDelete(DeleteBehavior.ClientNoAction);
    }
}