using Hony.Domain.Common;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hony.Infrastructure.Database.Configurations;

public abstract class EntityBaseConfiguration<T> : IEntityTypeConfiguration<T>
    where T : EntityBase
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasQueryFilter(x => x.IsActive);
        builder.HasIndex(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, value => new(value))
            .HasColumnName("id");
        builder.Property(x => x.IsActive).HasColumnName("is_active");
        builder.Property(x => x.RegisterDate).HasColumnName("register_date").IsRequired();
        builder.Property(x => x.RegisterTime).HasColumnName("register_time").IsRequired();
    }
}