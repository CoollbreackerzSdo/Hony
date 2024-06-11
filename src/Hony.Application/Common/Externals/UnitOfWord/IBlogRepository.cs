using System.Collections.Immutable;

using Hony.Domain.Common;
using Hony.Domain.Models.Blogs;

namespace Hony.Application.Common.Externals.UnitOfWord;

/// <summary>
/// Interfaz que define el repositorio para la entidad <see cref="BlogEntity"/>.
/// Hereda de <see cref="IRepository{BlogEntity}"/>.
/// </summary>
public interface IBlogRepository : IRepository<BlogEntity>
{
    /// <summary>
    /// Deshabilita un blog específico basado en su identificador y el identificador de su creador.
    /// </summary>
    /// <param name="blogId">El identificador del blog a deshabilitar.</param>
    /// <param name="creatorId">El identificador del creador del blog.</param>
    /// <returns>Un valor booleano que indica si la operación fue exitosa.</returns>
    bool ExecuteDisable(EntityKey<Guid> blogId, EntityKey<Guid> creatorId);
}