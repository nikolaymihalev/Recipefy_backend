using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Recipefy.Application.Contracts.Common;
using Recipefy.Domain.Common;

namespace Recipefy.Infrastructure.Persistence.Repositories;

public class DataRepository<TEntity> : IRepository<TEntity> where TEntity : class, IAggregateRoot
{
    private readonly DbContext _dbContext;

    internal DataRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    internal DbSet<TEntity> DbSet() => _dbContext.Set<TEntity>();
    
    public IQueryable<TEntity> GetAll() => this.DbSet().AsNoTracking();
    public async Task<TEntity?> GetByIdAsync(object id, CancellationToken cancellationToken = default) => await this.DbSet().FindAsync(id, cancellationToken);
    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default) => await this.DbSet().AddAsync(entity, cancellationToken);
    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) => await this.DbSet().AddRangeAsync(entities, cancellationToken);

    public async Task UpdateAsync(TEntity entity)
    {
        this.DbSet().Update(entity);
        await this.SaveChangesAsync();
    }

    public async Task RemoveAsync(TEntity entity)
    {
        this.DbSet().Remove(entity);
        
        await this.SaveChangesAsync();
    }

    public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();

    public async Task<IEnumerable<TEntity>> GetAllFilteredAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
     => await this.DbSet().AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
}