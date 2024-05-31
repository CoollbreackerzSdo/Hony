using System.Linq.Expressions;

using Hony.Domain.Common;

using Optional;

namespace Hony.Application.Common.Externals.UnitOfWord;

public interface IRepository<T>
    where T : EntityBase
{
    IQueryable<T> GetAll();
    Option<T> SingleAsOption(Expression<Func<T, bool>> expression);
    Option<T> FindAdOption<TKey>(TKey key);
    void Add(T model);
    void Remove<TKey>(TKey key);
    void Disable<TKey>(TKey key);
}