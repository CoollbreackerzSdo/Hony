using System.Linq.Expressions;

using Hony.Domain.Common;

using Optional;

namespace Hony.Application.Common.Externals.UnitOfWord;

/// <summary>
/// Interfaz genérica para un repositorio que proporciona operaciones CRUD básicas.
/// </summary>
/// <typeparam name="T">El tipo de entidad manejada por el repositorio.</typeparam>
public interface IRepository<T>
{
    /// <summary>
    /// Obtiene una consulta <see cref="IQueryable{T}"/> para todas las entidades del repositorio.
    /// </summary>
    /// <returns>Una consulta <see cref="IQueryable{T}"/> para todas las entidades.</returns>
    IQueryable<T> GetAll();

    /// <summary>
    /// Obtiene una única entidad que cumple con la expresión especificada como una opción.
    /// </summary>
    /// <param name="expression">La expresión utilizada para filtrar la entidad.</param>
    /// <returns>Una opción que contiene la entidad encontrada o <c>null</c> si no se encuentra ninguna.</returns>
    Option<T?> SingleAsOption(Expression<Func<T, bool>> expression);

    /// <summary>
    /// Determina si alguna entidad cumple con la expresión especificada.
    /// </summary>
    /// <param name="expression">La expresión utilizada para filtrar las entidades.</param>
    /// <returns><c>true</c> si se encuentra alguna entidad que cumpla con la expresión; de lo contrario, <c>false</c>.</returns>
    bool Any(Expression<Func<T, bool>> expression);

    /// <summary>
    /// Encuentra una entidad por su clave como una opción.
    /// </summary>
    /// <param name="key">La clave de la entidad a encontrar.</param>
    /// <returns>Una opción que contiene la entidad encontrada o <c>null</c> si no se encuentra ninguna.</returns>
    Option<T?> FindAdOption(EntityKey<Guid> key);

    /// <summary>
    /// Agrega una nueva entidad al repositorio.
    /// </summary>
    /// <param name="model">La entidad a agregar.</param>
    void Add(T model);

    /// <summary>
    /// Ejecuta la eliminación de una entidad identificada por su clave.
    /// </summary>
    /// <param name="key">La clave de la entidad a eliminar.</param>
    /// <returns><c>true</c> si la entidad se eliminó correctamente; de lo contrario, <c>false</c>.</returns>
    bool ExecuteRemove(EntityKey<Guid> key);

    /// <summary>
    /// Ejecuta la desactivación de una entidad identificada por su clave.
    /// </summary>
    /// <param name="key">La clave de la entidad a desactivar.</param>
    /// <returns><c>true</c> si la entidad se desactivó correctamente; de lo contrario, <c>false</c>.</returns>
    bool ExecuteDisable(EntityKey<Guid> key);
}