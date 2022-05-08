using FutStats.Domain.Entities;
using FutStats.Domain.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutStats.Infrastructure.Database.Repositories.FutStatsRepositories
{
    public class TeamRepository : EntitiesRepositoryBase<TeamEntity>, ITeamRepository
    {
        public TeamRepository(FutStatDbContext dbContext) : base(dbContext)
        {

        }
    }
}
