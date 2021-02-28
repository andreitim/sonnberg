using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Sonnberg.Persistance.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly SonnbergDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(SonnbergDbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(int id, CancellationToken cancellationToken = default)
            => await _dbSet.FindAsync(new object[] { id }, cancellationToken);

        public async Task<IReadOnlyCollection<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _dbSet.ToListAsync(cancellationToken);

        public async Task<IReadOnlyCollection<TEntity>> FindAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default)
            => await _dbSet.AsNoTracking()
                           .Where(predicate)
                           .ToListAsync(cancellationToken);

        public async Task<bool> AnyAsync(CancellationToken cancellationToken = default)
            => await _dbSet.AsNoTracking()
                           .AnyAsync(cancellationToken);

        public async Task<TEntity> SingleOrDefaultAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default)
            => await _dbSet.SingleOrDefaultAsync(predicate, cancellationToken);

        public virtual void Update(TEntity entity)
            => _dbSet.Add(entity);

        public virtual void Add(TEntity entity)
            => _dbContext.Entry(entity).State = EntityState.Modified;

        public virtual void AddRange(IReadOnlyCollection<TEntity> entities)
            => _dbSet.AddRange(entities);

        public void Remove(TEntity entity) => _dbSet.Remove(entity);

        public void RemoveRange(IReadOnlyCollection<TEntity> entities) => _dbSet.RemoveRange(entities);
    }
}
