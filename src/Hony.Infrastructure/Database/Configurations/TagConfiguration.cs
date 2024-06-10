using Hony.Domain.Models.Aggregates;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hony.Infrastructure.Database.Configurations;

/// <summary>
/// Configuración de la entidad <see cref="TagEntity"/> para el modelo de datos.
/// </summary>
public sealed class TagConfiguration : EntityBaseConfiguration<TagEntity>
{
    /// <summary>
    /// Configura las propiedades y relaciones de la entidad <see cref="TagEntity"/>.
    /// </summary>
    /// <param name="builder">El constructor de tipo de entidad que se está configurando.</param>
    public override void Configure(EntityTypeBuilder<TagEntity> builder)
    {
        base.Configure(builder);
        
        // Configuración del nombre del tag
        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsUnicode()
            .IsRequired()
            .HasColumnName("name");

        // Configuración del color del tag
        builder.OwnsOne(x => x.Color, nav => nav.ToJson());

        // Configuración de navegación con los blogs
        builder.HasMany(x => x.Blogs)
            .WithOne(x => x.Tag)
            .HasForeignKey(x => x.TagId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}