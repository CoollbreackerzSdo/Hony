using System.Linq.Expressions;

using Hony.Application.Common.Externals.UnitOfWord;
using Hony.Domain.Common;
using Hony.Infrastructure.Database;

using Optional;

namespace Hony.Infrastructure.Implementations.UnitOfWord;

internal class Repository<T> : IRepository<T>
    where T : EntityBase
{
    public Repository(HonyNpSqlContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }
    public IQueryable<T> GetAll() => _table;
    public Option<T?> SingleAsOption(Expression<Func<T, bool>> expression)
        => _table.SingleOrDefault(expression).SomeNotNull();
    public Option<T?> FindAdOption(EntityKey<Guid> key)
        => _table.Find(key).SomeNotNull();
    public void Add(T model)
        => _table.Add(model);
    public bool ExecuteRemove(EntityKey<Guid> key)
        => _table.Where(x => x.Id == key).ExecuteDelete() > 0;
    public bool ExecuteDisable(EntityKey<Guid> key)
        => _table.Where(x => x.Id == key).ExecuteUpdate(setter => setter.SetProperty(prop => prop.IsActive, false)) > 0;
    public bool Any(Expression<Func<T, bool>> expression)
        => _table.Any(expression);
    private readonly HonyNpSqlContext _context;
    private readonly DbSet<T> _table;
}