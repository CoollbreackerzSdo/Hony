using Hony.Domain.Models.Account;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hony.Infrastructure.Database.Configurations;

public sealed class AccountConfiguration : EntityBaseConfiguration<AccountEntity>
{
    public override void Configure(EntityTypeBuilder<AccountEntity> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.UserName).HasColumnName("user_name").IsRequired().IsUnicode();
        builder.HasIndex(x => x.UserName);
        builder.OwnsOne(x => x.Detail, navigation =>
        {
            navigation.ToJson();
            navigation.Property(x => x.LastName).HasColumnName("first_name").HasMaxLength(100);
            navigation.Property(x => x.FirstName).HasColumnName("first_name").HasMaxLength(100);
        });
        builder.OwnsOne(x => x.Security, navigation =>
        {
            navigation.Property(x => x.Email).HasColumnName("email").IsRequired().IsUnicode();
            navigation.Property(x => x.Password).HasColumnName("password").IsRequired();
        });
    }
}