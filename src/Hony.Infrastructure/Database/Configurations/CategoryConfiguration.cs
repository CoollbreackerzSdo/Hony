using Hony.Domain.Models.Aggregates;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hony.Infrastructure.Database.Configurations;

public sealed class CategoryConfiguration : EntityBaseConfiguration<CategoryEntity>
{
    public override void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        base.Configure(builder);

        //Configuración del nombre de la categoría 
        builder.Property(x => x.Name).HasMaxLength(100)
        .IsUnicode().IsRequired().HasColumnName("name");
        
        //Configuración del color de la categoría
        builder.OwnsOne(x => x.Color, nav => nav.ToJson());

        builder.HasMany(x => x.Blogs)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}