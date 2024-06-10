using Hony.Domain.Models.Combinations;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hony.Infrastructure.Database.Configurations;

/// <summary>
/// Configuración de la entidad <see cref="TagBlogEntity"/> para el modelo de datos.
/// </summary>
public sealed class TagBlogsConfiguration : EntityBaseConfiguration<TagBlogEntity>
{
    /// <summary>
    /// Configura las propiedades y relaciones de la entidad <see cref="TagBlogEntity"/>.
    /// </summary>
    /// <param name="builder">El constructor de tipo de entidad que se está configurando.</param>
    public override void Configure(EntityTypeBuilder<TagBlogEntity> builder)
    {
        base.Configure(builder);
    }
}