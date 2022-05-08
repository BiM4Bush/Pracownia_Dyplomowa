using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FutStats.Shared.Infrastructure
{
    public static class EntityFrameworkExtensions
    {
        public static IQueryable<T> IncluideMultiple<T>(this DbSet<T> dbSet, params Expression<Func<T, object>>[]? includes) where T : class
        {
            return dbSet.AsQueryable().IncludeMultiple(includes);
        }

        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[]? includes) where T: class
        {
            if (includes is not null)
            {
                query = includes.Aggregate(query,
                    (current, include) => current.Include(include));
            }

            return query;
        }
    }
}
