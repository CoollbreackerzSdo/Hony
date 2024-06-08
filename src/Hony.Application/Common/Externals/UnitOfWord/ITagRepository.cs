using Hony.Domain.Models.Aggregates;

namespace Hony.Application.Common.Externals.UnitOfWord;
/// <summary>
/// Interfaz que define un repositorio específico para las etiquetas para los blogs.
/// Hereda de <see cref="IRepository{T}"/> donde <c>T</c> es <see cref="TagEntity"/>.
/// </summary>
public interface ITagRepository : IRepository<TagEntity>;