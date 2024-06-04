using Hony.Domain.Models.Account;
using Hony.Infrastructure.Database.Configurations;

namespace Hony.Infrastructure.Database;

/// <summary>
/// Clase que representa el contexto de la base de datos para HonyNpSql.
/// Inicializa una nueva instancia de la clase <see cref="HonyNpSqlContext"/>.
/// </summary>
/// <param name="options">Las opciones del contexto de la base de datos.</param>
public sealed class HonyNpSqlContext(DbContextOptions options) : DbContext(options)
{
    /// Configura el modelo de base de datos durante la creación del contexto.
    /// </summary>
    /// <param name="modelBuilder">El constructor de modelos utilizado para construir el modelo de base de datos.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
    }

    /// <summary>
    /// Obtiene o establece el conjunto de entidades de cuentas en el contexto de la base de datos.
    /// </summary>
    public DbSet<AccountEntity> Accounts { get; init; } = null!;
}