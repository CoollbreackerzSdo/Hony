using Hony.Application.Common.Externals.UnitOfWord;
using Hony.Domain.Models.Blogs;
using Hony.Infrastructure.Database;

namespace Hony.Infrastructure.Implementations.UnitOfWord;
/// <summary>
/// Repositorio para la entidad <see cref="BlogEntity"/> que proporciona operaciones específicas para blogs.
/// Hereda de <see cref="Repository{BlogEntity}"/> e implementa <see cref="IBlogRepository"/>.
/// Inicializa una nueva instancia de la clase <see cref="BlogRepository"/> con el contexto de base de datos especificado.
/// </summary>
/// <param name="context">El contexto de base de datos utilizado para las operaciones de datos.</param>
internal class BlogRepository(HonyAccountsNpSqlContext context) : Repository<BlogEntity>(context), IBlogRepository;