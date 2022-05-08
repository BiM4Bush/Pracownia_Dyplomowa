using FutStats.Domain.Repositories;
using FutStats.Shared.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FutStats.Infrastructure.Database.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public async Task<bool> Exist(Expression<Func<T, bool>> findExpression, CancellationToken cancellationToken = default)
        {
            return await _dbSet.AnyAsync(findExpression, cancellationToken);
        }

        public Task<List<T>> GetAll(Expression<Func<T, bool>> findExpression, CancellationToken cancellationToken = default)
        {
            return _dbSet.Where(findExpression).ToListAsync(cancellationToken);
        }

        public Task<T> GetSingle(Expression<Func<T, bool>> findExpression, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes)
        {
            return _dbSet.IncludeMultiple(includes).SingleOrDefaultAsync(findExpression, cancellationToken);
        }

        public async Task<IReadOnlyCollection<T>> ReadAll(CancellationToken cancellationToken = default)
        {
            return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyCollection<T>> ReadAll(Expression<Func<T, bool>> findExpression, CancellationToken cancellationToken)
        {
            return await _dbSet.AsNoTracking().Where(findExpression).ToListAsync(cancellationToken);
        }

        public Task<T> ReadSingle(Expression<Func<T, bool>> findExpression, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes)
        {
            return _dbSet.AsNoTracking().IncludeMultiple(includes).SingleOrDefaultAsync(findExpression, cancellationToken);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
