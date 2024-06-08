using Hony.Domain.Models.Account;
using Hony.Domain.Models.Aggregates;
using Hony.Domain.Models.Blogs;
using Hony.Domain.Models.Combinations;
using Hony.Infrastructure.Database.Configurations;

namespace Hony.Infrastructure.Database;

/// <summary>
/// Clase que representa el contexto de la base de datos para HonyNpSql.
/// Inicializa una nueva instancia de la clase <see cref="HonyAccountsNpSqlContext"/>.
/// </summary>
/// <param name="options">Las opciones del contexto de la base de datos.</param>
public sealed class HonyAccountsNpSqlContext(DbContextOptions options) : DbContext(options)
{
    /// Configura el modelo de base de datos durante la creación del contexto.
    /// </summary>
    /// <param name="modelBuilder">El constructor de modelos utilizado para construir el modelo de base de datos.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
        modelBuilder.ApplyConfiguration(new BlogConfiguration());
        modelBuilder.ApplyConfiguration(new TagBlogsConfiguration());
        modelBuilder.ApplyConfiguration(new TagConfiguration());
    }

    /// <summary>
    /// Obtiene o establece el conjunto de entidades de cuentas en el contexto de la base de datos.
    /// </summary>
    public DbSet<AccountEntity> Accounts { get; init; } = null!;
    /// <summary>
    /// Conjunto de entidades de tipo <see cref="BlogEntity"/> en el contexto de la base de datos.
    /// </summary>
    public DbSet<BlogEntity> Blogs { get; init; } = null!;
    /// <summary>
    /// Conjunto de entidades de tipo <see cref="CommentEntity"/> en el contexto de la base de datos.
    /// </summary>
    public DbSet<CommentEntity> Comments { get; init; } = null!;
    /// <summary>
    /// Conjunto de entidades de tipo <see cref="TagEntity"/> en el contexto de la base de datos.
    /// </summary>
    public DbSet<TagEntity> Tags { get; init; } = null!;
    /// <summary>
    /// Conjunto de entidades de tipo <see cref="TagBlogEntity"/> en el contexto de la base de datos.
    /// </summary>
    public DbSet<TagBlogEntity> TagAndBlogs { get; init; } = null!;
    /// <summary>
    /// Conjunto de entidades de tipo <see cref="CategoryEntity"/> en el contexto de la base de datos.
    /// </summary>
    public DbSet<CategoryEntity> Categories { get; init; } = null!;
}