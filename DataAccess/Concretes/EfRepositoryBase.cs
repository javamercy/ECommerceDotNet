using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes;

public class EFfRepositoryBase<TEntity, TContext> : IAsyncRepository<TEntity>
    where TEntity : class, new()
    where TContext : DbContext, new()
{
    protected readonly TContext Context;

    public EFfRepositoryBase(TContext context)
    {
        Context = context;
    }

    public async Task AddAsync(TEntity entity)
    {
        var addedEntity = Context.Entry(entity);
        addedEntity.State = EntityState.Added;
        await Context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        var updatedEntity = Context.Entry(entity);
        updatedEntity.State = EntityState.Modified;
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        var deletedEntity = Context.Entry(entity);
        deletedEntity.State = EntityState.Deleted;
        await Context.SaveChangesAsync();
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
    }

    public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
        return predicate == null
            ? await Context.Set<TEntity>().ToListAsync()
            : await Context.Set<TEntity>().Where(predicate).ToListAsync();
    }
}

public interface IAsyncRepository<TEntity>
{
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate);
}
