using System.Linq.Expressions;

namespace TeamTrain.Domain.Interfaces;

public interface IRepository<T> where T : class, IEntity<Guid>
{
    Task<T?> GetByIdAsync(Guid id);
    Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);

    Task AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
}
