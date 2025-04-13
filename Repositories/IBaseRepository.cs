using System;
using System.Linq.Expressions;

namespace BloggerBits.Repositories;

public interface IBaseRepository<T> where T:class
{
   #region Get
        //IQueryable<T> Active();
        Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IQueryable<T>> GetAllAsync();
        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);

        #endregion Get

        #region Save
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task<List<T>> AddRangeAsync(List<T> entities, CancellationToken cancellationToken = default);

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
        #endregion Save

        #region Update
        Task UpdateAsync(T entity);
        #endregion Update

        #region Delete
        Task DeleteAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        #endregion Delete
}
