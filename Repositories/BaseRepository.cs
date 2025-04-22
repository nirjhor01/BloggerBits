using System;
using System.Linq.Expressions;
using BloggerBits.Database;
using Microsoft.EntityFrameworkCore;

namespace BloggerBits.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    #region Get
    public IQueryable<T> Active()
    {
        return _context.Set<T>().Where(e => EF.Property<bool>(e, "isActive")).AsNoTracking();
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);
    }

    public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression).AsNoTracking();
    }

    public async Task<IList<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
    }
    #endregion

    #region Save
    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _context.Set<T>().AddAsync(entity, cancellationToken);
        return entity;
    }

    public async Task<IList<T>> AddRangeAsync(IList<T> entities, CancellationToken cancellationToken = default)
    {
        await _context.Set<T>().AddRangeAsync(entities, cancellationToken);
        return entities;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
    #endregion

    #region Update
    public Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        return Task.CompletedTask;
    }
    #endregion

    #region Delete
    public Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        return Task.CompletedTask;
    }

    public async Task RemoveRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        _context.Set<T>().RemoveRange(entities);
        await SaveChangesAsync(cancellationToken);
    }
    #endregion

}
