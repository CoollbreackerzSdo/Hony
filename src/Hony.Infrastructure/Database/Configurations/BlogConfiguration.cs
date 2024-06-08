using Hony.Domain.Models.Blogs;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Hony.Infrastructure.Database.Configurations;

/// <summary>
/// Configuración de la entidad <see cref="BlogEntity"/> para el contexto de base de datos.
/// </summary>
public sealed class BlogConfiguration : EntityBaseConfiguration<BlogEntity>
{
    /// <summary>
    /// Configura las propiedades y relaciones de la entidad <see cref="BlogEntity"/>.
    /// </summary>
    /// <param name="builder">El constructor utilizado para configurar la entidad.</param>
    public override void Configure(EntityTypeBuilder<BlogEntity> builder)
    {
        base.Configure(builder);

        // Configuración de la propiedad Name
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(1_000)
            .HasColumnName("name");

        // Configuración de las propiedades de tiempo
        builder.Property(x => x.RegisterDate).HasColumnName("register_date").IsRequired();
        builder.Property(x => x.RegisterTime).HasColumnName("register_time").IsRequired();

        // Configuración de la propiedad Content
        builder.Property(x => x.Content)
            .IsRequired()
            .HasMaxLength(10_000)
            .HasColumnName("content");

        // Configuración de la propiedad CreatorId
        builder.Property(x => x.CreatorId)
            .IsRequired();

        // Configuración del tipo de propiedad Detail
        builder.OwnsOne(x => x.Detail, navigation =>
        {
            navigation.ToJson();
            navigation.Property(x => x.ReTwits)
                .HasDefaultValue(0)
                .HasColumnName("re_twits");
        });

        // Configuración de la relación con la entidad CommentEntity
        builder.HasMany(x => x.Comments)
            .WithOne(x => x.Blog)
            .HasForeignKey(x => x.BlogId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}