using System.Linq.Expressions;
using Model.Base;
using Microsoft.EntityFrameworkCore;

namespace Repository.Base.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class, IBaseEntity
    {
        DbSet<TEntity> Entities { get; }
        //IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }

        Task AddAsync(TEntity entity, CancellationToken cancellationToken);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] ids);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
