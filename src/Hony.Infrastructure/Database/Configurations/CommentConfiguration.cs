using Hony.Domain.Models.Twits;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hony.Infrastructure.Database.Configurations;

/// <summary>
/// Configuración de la entidad <see cref="CommentEntity"/> para el contexto de base de datos.
/// </summary>
public sealed class CommentConfiguration : EntityBaseConfiguration<CommentEntity>
{
    /// <summary>
    /// Configura las propiedades y relaciones de la entidad <see cref="CommentEntity"/>.
    /// </summary>
    /// <param name="builder">El constructor utilizado para configurar la entidad.</param>
    public override void Configure(EntityTypeBuilder<CommentEntity> builder)
    {
        base.Configure(builder);

        // Configuración de la propiedad Message
        builder.Property(x => x.Message)
            .IsRequired()
            .HasMaxLength(5_000);
    }
}