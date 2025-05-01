using System.Linq.Expressions;
using DataAccess.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace DataAccess.Concretes;

public class EfRepositoryBase<TEntity, TContext> : IAsyncRepository<TEntity>
    where TEntity : class, new()
    where TContext : DbContext, new()
{
    protected readonly TContext Context;

    public EfRepositoryBase(TContext context)
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

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        var queryable = Query();
        if (include != null) queryable = include(queryable);

        return await queryable.FirstOrDefaultAsync(predicate);
    }

    public IQueryable<TEntity> Query()
    {
        return Context.Set<TEntity>();
    }

    public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        var queryable = Query();

        if (include != null) queryable = include(queryable);

        if (predicate != null) queryable = queryable.Where(predicate);

        return await queryable.ToListAsync();
    }
}