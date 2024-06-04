using Hony.Domain.Common;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hony.Infrastructure.Database.Configurations;

/// <summary>
/// Clase abstracta que proporciona configuración base para mapear entidades que heredan de <see cref="EntityBase"/>.
/// </summary>
/// <typeparam name="T">El tipo de entidad a configurar.</typeparam>
public abstract class EntityBaseConfiguration<T> : IEntityTypeConfiguration<T>
    where T : EntityBase
{
    /// <summary>
    /// Configura el mapeo de la entidad.
    /// </summary>
    /// <param name="builder">El constructor de entidades utilizado para configurar el mapeo.</param>
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasQueryFilter(x => x.IsActive);
        builder.HasIndex(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, value => new EntityKey<Guid>(value))
            .HasColumnName("id");
        builder.Property(x => x.IsActive).HasColumnName("is_active");
        builder.Property(x => x.RegisterDate).HasColumnName("register_date").IsRequired();
        builder.Property(x => x.RegisterTime).HasColumnName("register_time").IsRequired();
    }
}