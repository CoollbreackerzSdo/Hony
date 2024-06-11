using System.Text.Json;

using Hony.Domain.Models.Aggregates;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hony.Infrastructure.Database.Configurations;

/// <summary>
/// Configuración de la entidad <see cref="CategoryEntity"/> para el modelo de datos.
/// </summary>
public sealed class CategoryConfiguration : EntityBaseConfiguration<CategoryEntity>
{
    /// <summary>
    /// Configura las propiedades y relaciones de la entidad <see cref="CategoryEntity"/>.
    /// </summary>
    /// <param name="builder">El constructor de tipo de entidad que se está configurando.</param>
    public override void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        base.Configure(builder);

        // Configuración del nombre de la categoría 
        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsUnicode()
            .IsRequired()
            .HasColumnName("name");

        // Configuración del color de la categoría
        builder.OwnsOne(x => x.Color, nav => nav.ToJson());

        // Configuración de la relación con Blogs
        builder.HasMany(x => x.Blogs)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}