using System.Linq.Expressions;

using Hony.Domain.Common;

using Optional;

namespace Hony.Application.Common.Externals.UnitOfWord;

public interface IRepository<T>
{
    IQueryable<T> GetAll();
    Option<T?> SingleAsOption(Expression<Func<T, bool>> expression);
    bool Any(Expression<Func<T, bool>> expression);
    Option<T?> FindAdOption(EntityKey<Guid> key);
    void Add(T model);
    bool ExecuteRemove(EntityKey<Guid> key);
    bool ExecuteDisable(EntityKey<Guid> key);
}