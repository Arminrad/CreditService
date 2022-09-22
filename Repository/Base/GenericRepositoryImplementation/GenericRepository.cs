using Common.Utilities;
using Microsoft.EntityFrameworkCore;
using Model.Base.Interfaces;
using Repository.Base.GenericRepositoryInterface;
using Repository.Connection;

namespace Repository.Base.GenericRepositoryImplementation
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IBaseEntity
    {
        protected readonly CreditContext DbContext;
        public DbSet<TEntity> Entities { get; }
        //public virtual IQueryable<TEntity> Table => Entities;
        public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        public GenericRepository(CreditContext dbContext)
        {
            DbContext = dbContext;
            Entities = DbContext.Set<TEntity>(); // City => Cities
        }

        #region Methods
        public virtual async Task<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] ids)
        {
            return await Entities.FindAsync(ids, cancellationToken);
        }

        public virtual async Task<TEntity> GetbyIdAsyncTask(object id, CancellationToken cancellationToken)
        {
            return await Entities.FindAsync(id, cancellationToken);
        }

        public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            Assert.NotNull(entity, nameof(entity));
            await Entities.AddAsync(entity, cancellationToken).ConfigureAwait(false);
            await DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            Assert.NotNull(entity, nameof(entity));
            Entities.Update(entity);
            await DbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            Assert.NotNull(entity, nameof(entity));
            Entities.Remove(entity);
            await DbContext.SaveChangesAsync(cancellationToken);
        }
        #endregion
    }
}
