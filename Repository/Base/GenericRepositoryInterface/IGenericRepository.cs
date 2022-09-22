using Microsoft.EntityFrameworkCore;
using Model.Base.Interfaces;

namespace Repository.Base.GenericRepositoryInterface
{
    public interface IGenericRepository<TEntity> where TEntity : class, IBaseEntity
    {
        DbSet<TEntity> Entities { get; }
        //IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }

        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity> GetByIdAsync(CancellationToken cancellationToken = default, params object[] ids);
        Task<TEntity> GetbyIdAsyncTask(object id, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
