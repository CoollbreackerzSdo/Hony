using Hony.Application.Common.Externals.UnitOfWord;
using Hony.Domain.Models.Aggregates;
using Hony.Infrastructure.Database;

namespace Hony.Infrastructure.Implementations.UnitOfWord; 
/// <summary>
/// Repositorio para la entidad <see cref="TagEntity"/> que proporciona operaciones específicas para etiquetas.
/// Hereda de <see cref="Repository{TagEntity}"/> e implementa <see cref="ITagRepository"/>.
/// Inicializa una nueva instancia de la clase <see cref="TagRepository"/> con el contexto de base de datos especificado.
/// </summary>
/// <param name="context">El contexto de base de datos utilizado para las operaciones de datos.</param>
internal sealed class TagRepository(HonyAccountsNpSqlContext context) : Repository<TagEntity>(context), ITagRepository;