using FUTStats.Infrastructure.Interfaces;
using FUTStats.Infrastructure.Persistance.DbContexts;
using FUTStats.Infrastructure.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FUTStats.Infrastructure.Persistance.Repositories
{
    public class TeamRepository : BaseRepository<TeamEntity>, ITeamRepository
    {
        protected readonly FutStatsDbContext _futStatsDbContext;
        public TeamRepository(FutStatsDbContext futStatsDbContext): base(futStatsDbContext)
        {
            this._futStatsDbContext = futStatsDbContext;
        }
        public async Task<int> CreateTeamAsync(TeamEntity entity)
        {
            await _futStatsDbContext.Set<TeamEntity>().AddAsync(entity);
            return await _futStatsDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteTeamAsync(TeamEntity entity)
        {
            _futStatsDbContext.Set<TeamEntity>().Remove(entity);
            return await _futStatsDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<TeamEntity>> GetAllTeams()
        {
            return await _futStatsDbContext.Set<TeamEntity>().ToListAsync();
        }

        public async Task<TeamEntity> GetTeamAsync(Guid guid)
        {
            return await _futStatsDbContext.Set<TeamEntity>().FindAsync(guid);
        }

        public async Task<int> UpdateTeamAsync(TeamEntity entity)
        {
            _futStatsDbContext.Set<TeamEntity>().Update(entity);
            return await _futStatsDbContext.SaveChangesAsync();
        }
    }
}
