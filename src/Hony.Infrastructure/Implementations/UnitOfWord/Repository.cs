using System.Linq.Expressions;

using Hony.Application.Common.Externals.UnitOfWord;
using Hony.Domain.Common;
using Hony.Infrastructure.Database;

using Optional;

namespace Hony.Infrastructure.Implementations.UnitOfWord;

/// <summary>
/// Clase interna que proporciona implementaciones predeterminadas para operaciones CRUD en entidades del tipo especificado.
/// Implementa la interfaz <see cref="IRepository{T}"/> donde <c>T</c> es una clase que hereda de <see cref="EntityBase"/>.
/// </summary>
/// <typeparam name="T">El tipo de entidad gestionada por el repositorio.</typeparam>
internal class Repository<T> : IRepository<T>
    where T : EntityBase
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Repository{T}"/>.
    /// </summary>
    /// <param name="context">El contexto de la base de datos utilizado por el repositorio.</param>
    public Repository(HonyNpSqlContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }

    /// <summary>
    /// Obtiene todas las entidades del tipo especificado.
    /// </summary>
    /// <returns>Una consulta que representa todas las entidades del tipo especificado.</returns>
    public IQueryable<T> GetAll() => _table;

    /// <summary>
    /// Obtiene una opción que contiene la única entidad del tipo especificado que coincide con la condición proporcionada.
    /// </summary>
    /// <param name="expression">La condición para seleccionar la entidad.</param>
    /// <returns>Una opción que contiene la única entidad encontrada o ninguna si no se encuentra ninguna coincidencia.</returns>
    public Option<T?> SingleAsOption(Expression<Func<T, bool>> expression)
        => _table.SingleOrDefault(expression).SomeNotNull();

    /// <summary>
    /// Obtiene una opción que contiene la entidad del tipo especificado con la clave primaria especificada.
    /// </summary>
    /// <param name="key">La clave primaria de la entidad.</param>
    /// <returns>Una opción que contiene la entidad encontrada o ninguna si no se encuentra ninguna coincidencia.</returns>
    public Option<T?> FindAdOption(EntityKey<Guid> key)
        => _table.Find(key).SomeNotNull();

    /// <summary>
    /// Agrega una nueva entidad al repositorio.
    /// </summary>
    /// <param name="model">La entidad a agregar.</param>
    public void Add(T model)
        => _table.Add(model);

    /// <summary>
    /// Ejecuta una eliminación de la entidad con la clave primaria especificada.
    /// </summary>
    /// <param name="key">La clave primaria de la entidad a eliminar.</param>
    /// <returns><c>true</c> si se elimina la entidad correctamente; de lo contrario, <c>false</c>.</returns>
    public bool ExecuteRemove(EntityKey<Guid> key)
        => _table.Where(x => x.Id == key).ExecuteDelete() > 0;

    /// <summary>
    /// Ejecuta una desactivación de la entidad con la clave primaria especificada.
    /// </summary>
    /// <param name="key">La clave primaria de la entidad a desactivar.</param>
    /// <returns><c>true</c> si se desactiva la entidad correctamente; de lo contrario, <c>false</c>.</returns>
    public bool ExecuteDisable(EntityKey<Guid> key)
        => _table.Where(x => x.Id == key).ExecuteUpdate(setter => setter.SetProperty(prop => prop.IsActive, false)) > 0;

    /// <summary>
    /// Comprueba si alguna entidad del tipo especificado satisface la condición proporcionada.
    /// </summary>
    /// <param name="expression">La condición para verificar.</param>
    /// <returns><c>true</c> si alguna entidad satisface la condición; de lo contrario, <c>false</c>.</returns>
    public bool Any(Expression<Func<T, bool>> expression)
        => _table.Any(expression);

    private readonly HonyNpSqlContext _context;
    private readonly DbSet<T> _table;
}