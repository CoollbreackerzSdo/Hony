using System.Collections.Immutable;
using System.Linq.Expressions;

using Hony.Application.Common.Externals.UnitOfWord;
using Hony.Application.Common.Models;
using Hony.Domain.Common;
using Hony.Infrastructure.Database;

using Optional;

namespace Hony.Infrastructure.Implementations.UnitOfWord;

/// <summary>
/// Clase interna que proporciona implementaciones predeterminadas para operaciones CRUD en entidades del tipo especificado.
/// Implementa la interfaz <see cref="IRepository{T}"/> donde <c>T</c> es una clase que hereda de <see cref="EntityBase"/>.
/// </summary>
/// <typeparam name="T">El tipo de entidad gestionada por el repositorio.</typeparam>
internal abstract class Repository<T> : IRepository<T>
    where T : EntityBase
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Repository{T}"/>.
    /// </summary>
    /// <param name="context">El contexto de la base de datos utilizado por el repositorio.</param>
    public Repository(HonyAccountsNpSqlContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }

    /// <summary>
    /// Obtiene todas las entidades del tipo especificado.
    /// </summary>
    /// <returns>Una consulta que representa todas las entidades del tipo especificado.</returns>
    public virtual IQueryable<T> GetAll() => _table;

    /// <summary>
    /// Obtiene una opción que contiene la única entidad del tipo especificado que coincide con la condición proporcionada.
    /// </summary>
    /// <param name="expression">La condición para seleccionar la entidad.</param>
    /// <returns>Una opción que contiene la única entidad encontrada o ninguna si no se encuentra ninguna coincidencia.</returns>
    public virtual Option<T?> SingleAsOption(Expression<Func<T, bool>> expression)
        => _table.SingleOrDefault(expression).SomeNotNull();

    /// <summary>
    /// Obtiene una opción que contiene la entidad del tipo especificado con la clave primaria especificada.
    /// </summary>
    /// <param name="key">La clave primaria de la entidad.</param>
    /// <returns>Una opción que contiene la entidad encontrada o ninguna si no se encuentra ninguna coincidencia.</returns>
    public virtual Option<T?> FindAdOption(EntityKey<Guid> key)
        => _table.Find(key).SomeNotNull();

    /// <summary>
    /// Agrega una nueva entidad al repositorio.
    /// </summary>
    /// <param name="model">La entidad a agregar.</param>
    public virtual void Add(T model)
        => _table.Add(model);

    /// <summary>
    /// Ejecuta una eliminación de la entidad con la clave primaria especificada.
    /// </summary>
    /// <param name="key">La clave primaria de la entidad a eliminar.</param>
    /// <returns><c>true</c> si se elimina la entidad correctamente; de lo contrario, <c>false</c>.</returns>
    public virtual bool ExecuteRemove(EntityKey<Guid> key)
        => _table.Where(x => x.Id == key).ExecuteDelete() > 0;

    /// <summary>
    /// Ejecuta una desactivación de la entidad con la clave primaria especificada.
    /// </summary>
    /// <param name="key">La clave primaria de la entidad a desactivar.</param>
    /// <returns><c>true</c> si se desactiva la entidad correctamente; de lo contrario, <c>false</c>.</returns>
    public virtual bool ExecuteDisable(EntityKey<Guid> key)
        => _table.Where(x => x.Id == key).ExecuteUpdate(setter => setter.SetProperty(prop => prop.IsActive, false)) > 0;

    /// <summary>
    /// Comprueba si alguna entidad del tipo especificado satisface la condición proporcionada.
    /// </summary>
    /// <param name="expression">La condición para verificar.</param>
    /// <returns><c>true</c> si alguna entidad satisface la condición; de lo contrario, <c>false</c>.</returns>
    public virtual bool Any(Expression<Func<T, bool>> expression)
        => _table.Any(expression);
    /// <summary>
    /// Agrega una nueva entidad a la base de datos y devuelve la entidad agregada.
    /// </summary>
    /// <param name="model">La entidad a agregar.</param>
    /// <returns>La entidad agregada.</returns>
    public virtual T AddTrack(T model)
    {
        _table.Add(model);
        return model;
    }
    /// <summary>
    /// Realiza paginación en una secuencia de elementos.
    /// </summary>
    /// <typeparam name="T">El tipo de elementos en la secuencia.</typeparam>
    /// <param name="command">El comando de paginación que contiene los parámetros de paginación.</param>
    /// <returns>Una consulta <see cref="IQueryable{T}"/> que representa la página de elementos.</returns>
    public virtual IQueryable<T> Pagination<TKey>(PaginationCommandHandler command, Expression<Func<T, TKey>> pageFilterSelector)
    {
        var query = _table.AsQueryable();
        var queryOrder = command.OrderMode switch
        {
            PageOrderMode.Desc => query.OrderBy(pageFilterSelector),
            _ => query.OrderByDescending(pageFilterSelector)
        };
        return queryOrder.Skip(command.Skip).Take(command.Count);
    }
    private protected readonly HonyAccountsNpSqlContext _context;
    private protected readonly DbSet<T> _table;
}