using FutStats.Domain.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutStats.Infrastructure.Database.Repositories.FutStatsRepositories
{
    public class EntitiesRepositoryBase<T> : Repository<T>, IEntitiesRepository<T> where T : class
    {
        protected readonly FutStatDbContext _dbContext;
        public EntitiesRepositoryBase(FutStatDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
    }
}
