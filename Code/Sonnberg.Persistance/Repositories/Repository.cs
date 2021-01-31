using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sonnberg.Persistance.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(SonnbergDbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(int id)
            => await _dbSet.FindAsync(id);

        public async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
            => await _dbSet.ToListAsync();

        public async Task<IReadOnlyCollection<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
            => await _dbSet.AsNoTracking()
                           .Where(predicate)
                           .ToListAsync();

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate) => _dbSet.SingleOrDefault(predicate);

        public void Add(TEntity entity) => _dbSet.Add(entity);

        public void AddRange(IEnumerable<TEntity> entities) => _dbSet.AddRange(entities);

        public void Remove(TEntity entity) => _dbSet.Remove(entity);

        public void RemoveRange(IEnumerable<TEntity> entities) => _dbSet.RemoveRange(entities);
    }
}
