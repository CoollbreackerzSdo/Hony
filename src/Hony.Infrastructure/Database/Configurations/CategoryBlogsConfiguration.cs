using Hony.Domain.Models.Combinations;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hony.Infrastructure.Database.Configurations;

/// <summary>
/// Configuración de la entidad <see cref="CategoryBlogsEntity"/> para el modelo de datos.
/// </summary>
public sealed class CategoryBlogsConfiguration : EntityBaseConfiguration<CategoryBlogsEntity>
{
    /// <summary>
    /// Configura las propiedades y relaciones de la entidad <see cref="CategoryBlogsEntity"/>.
    /// </summary>
    /// <param name="builder">El constructor de tipo de entidad que se está configurando.</param>
    public override void Configure(EntityTypeBuilder<CategoryBlogsEntity> builder)
    {
        base.Configure(builder);
    } 
}