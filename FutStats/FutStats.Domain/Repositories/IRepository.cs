using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FutStats.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetSingle(Expression<Func<T, bool>> findExpression, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes);

        Task<T?> ReadSingle(Expression<Func<T, bool>> findExpression, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes);

        Task<List<T>> GetAll(Expression<Func<T, bool>> findExpression, CancellationToken cancellationToken = default);

        Task<IReadOnlyCollection<T>> ReadAll(CancellationToken cancellationToken = default);

        Task<IReadOnlyCollection<T>> ReadAll(Expression<Func<T, bool>> findExpression, CancellationToken cancellationToken);

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        Task<bool> Exist(Expression<Func<T, bool>> findExpression, CancellationToken cancellationToken = default);
    }
}
