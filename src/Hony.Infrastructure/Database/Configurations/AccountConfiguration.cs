using Hony.Domain.Models.Account;
using Hony.Domain.Models.Blogs;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hony.Infrastructure.Database.Configurations;

/// <summary>
/// Clase que configura el mapeo de la entidad <see cref="AccountEntity"/> en la base de datos.
/// </summary>
public sealed class AccountConfiguration : EntityBaseConfiguration<AccountEntity>
{
    /// <summary>
    /// Configura el mapeo de la entidad <see cref="AccountEntity"/> en la base de datos.
    /// </summary>
    /// <param name="builder">El constructor de entidades utilizado para configurar el mapeo.</param>
    public override void Configure(EntityTypeBuilder<AccountEntity> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.UserName).HasColumnName("user_name").IsRequired().IsUnicode();
        builder.HasIndex(x => x.UserName);
        builder.OwnsOne(x => x.Detail, navigation =>
        {
            navigation.ToJson();
            navigation.Property(x => x.LastName).HasColumnName("last_name").HasMaxLength(100);
            navigation.Property(x => x.FirstName).HasColumnName("first_name").HasMaxLength(100);
        });
        builder.OwnsOne(x => x.Security, navigation =>
        {
            navigation.Property(x => x.Email).HasColumnName("email").IsRequired().IsUnicode();
            navigation.Property(x => x.Password).HasColumnName("password").IsRequired();
        });
        builder.HasMany(x => x.Blogs)
            .WithOne()
            .HasForeignKey(x => x.CreatorId)
            .IsRequired()
            .OnDelete(DeleteBehavior.ClientNoAction);
        builder.HasMany(x => x.Comments)
            .WithOne()
            .HasForeignKey(x => x.CreatorId)
            .IsRequired()
            .OnDelete(DeleteBehavior.ClientNoAction);
    }
}