using Hony.Domain.Models.Blogs;

namespace Hony.Application.Common.Externals.UnitOfWord;

/// <summary>
/// Interfaz que define el repositorio para la entidad <see cref="BlogEntity"/>.
/// Hereda de <see cref="IRepository{BlogEntity}"/>.
/// </summary>
public interface IBlogRepository : IRepository<BlogEntity>
{
}