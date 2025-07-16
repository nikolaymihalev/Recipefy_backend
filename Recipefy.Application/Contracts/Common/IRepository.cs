using System.Linq.Expressions;
using Recipefy.Domain.Common;

namespace Recipefy.Application.Contracts.Common;

public interface IRepository<TEntity> where TEntity : class, IAggregateRoot
{
    IQueryable<TEntity> GetAll();
    Task<TEntity?> GetByIdAsync(object id, CancellationToken cancellationToken = default);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    Task UpdateAsync(TEntity entity);
    Task RemoveAsync(TEntity entity);
    Task SaveChangesAsync();
    Task<IEnumerable<TEntity>> GetAllFilteredAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
}