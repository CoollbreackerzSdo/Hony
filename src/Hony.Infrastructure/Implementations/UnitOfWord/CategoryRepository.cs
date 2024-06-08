using Hony.Application.Common.Externals.UnitOfWord;
using Hony.Domain.Models.Aggregates;
using Hony.Infrastructure.Database;

namespace Hony.Infrastructure.Implementations.UnitOfWord;

/// <summary>
/// Repositorio para la entidad <see cref="CategoryEntity"/> que proporciona operaciones específicas para las categorías.
/// Hereda de <see cref="Repository{CategoryEntity}"/> e implementa <see cref="ICategoryRepository"/>.
/// Inicializa una nueva instancia de la clase <see cref="CategoryRepository"/> con el contexto de base de datos especificado.
/// </summary>
/// <param name="context">El contexto de base de datos utilizado para las operaciones de datos.</param>
internal sealed class CategoryRepository(HonyAccountsNpSqlContext context) : Repository<CategoryEntity>(context), ICategoryRepository;