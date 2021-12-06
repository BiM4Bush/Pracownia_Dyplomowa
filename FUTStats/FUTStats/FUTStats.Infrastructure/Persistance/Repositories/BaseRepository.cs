using FUTStats.Infrastructure.Interfaces;
using FUTStats.Infrastructure.Persistance.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FUTStats.Infrastructure.Persistance.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected FutStatsDbContext _futStatsDbContext { get; set; }
        public BaseRepository(FutStatsDbContext futStatsDbContext)
        {
            this._futStatsDbContext = futStatsDbContext;
        }
        public IQueryable<T> FindAll()
        {
            return this._futStatsDbContext.Set<T>().AsNoTracking();
        }
    }
}
