using Hony.Domain.Models.Aggregates;

namespace Hony.Application.Common.Externals.UnitOfWord;
/// <summary>
/// Interfaz que define un repositorio específico para las categorías.
/// Hereda de <see cref="IRepository{T}"/> donde <c>T</c> es <see cref="CategoryEntity"/>.
/// </summary>
public interface ICategoryRepository : IRepository<CategoryEntity>;