using Hony.Domain.Models.Account;
using Hony.Infrastructure.Database.Configurations;

namespace Hony.Infrastructure.Database;

public class HonyNpSqlContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
    }
    public DbSet<AccountEntity> Accounts { get; init; } = null!;
}