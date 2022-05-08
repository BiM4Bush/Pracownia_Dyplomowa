using FutStats.Domain.Entities;
using FutStats.Domain.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutStats.Infrastructure.Database.Repositories.FutStatsRepositories
{
    public class StatisticRepository : EntitiesRepositoryBase<StatisticEntity>, IStatisticRepository
    {
        public StatisticRepository(FutStatDbContext dbContext) : base(dbContext)
        {

        }
    }
}
