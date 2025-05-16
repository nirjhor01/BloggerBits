using System;
using System.Linq.Expressions;

namespace BloggerBits.Repositories;

public interface IBaseRepository<T> where T : class
{
        #region Get
        IQueryable<T> Active();
        Task<bool> RecordExistsAsync(Expression<Func<T, bool>> expression);
        Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IList<T>> GetAllAsync(CancellationToken cancellationToken = default);
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
        #endregion

        #region Save
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task<IList<T>> AddRangeAsync(IList<T> entities, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
        #endregion

        #region Update
        Task UpdateAsync(T entity);
        #endregion

        #region Delete
        Task DeleteAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        #endregion
}
