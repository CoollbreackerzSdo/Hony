using Hony.Application.Common.Externals.UnitOfWord;
using Hony.Domain.Models.Combinations;
using Hony.Infrastructure.Database;

namespace Hony.Infrastructure.Implementations.UnitOfWord;
/// <summary>
/// Repositorio para la entidad <see cref="CategoryBlogsEntity"/> utilizando el contexto HonyAccountsNpSql.
/// </summary>
/// <param name="context">El contexto de base de datos.</param>
internal class CategoryBlogsRepository(HonyAccountsNpSqlContext context) : Repository<CategoryBlogsEntity>(context), ICategoryBlogsRepository;