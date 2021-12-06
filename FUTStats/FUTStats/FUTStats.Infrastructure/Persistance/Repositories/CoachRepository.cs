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
    public class CoachRepository : BaseRepository<CoachEntity>, ICoachRepository
    {
        protected readonly FutStatsDbContext _futStatsDbContext;
        public CoachRepository(FutStatsDbContext futStatsDbContext): base(futStatsDbContext)
        {
            this._futStatsDbContext = futStatsDbContext;
        }
        public async Task<int> CreateCoachAsync(CoachEntity entity)
        {
            await _futStatsDbContext.Set<CoachEntity>().AddAsync(entity);
            return await _futStatsDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteCoachAsync(CoachEntity entity)
        {
            _futStatsDbContext.Set<CoachEntity>().Remove(entity);
            return await _futStatsDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<CoachEntity>> GetAllCoaches()
        {
            return await _futStatsDbContext.Set<CoachEntity>().ToListAsync();
        }

        public async Task<CoachEntity> GetCoachAsync(Guid guid)
        {
            return await _futStatsDbContext.Set<CoachEntity>().FindAsync(guid);
        }

        public async Task<int> UpdateCoachAsync(CoachEntity entity)
        {
            _futStatsDbContext.Set<CoachEntity>().Update(entity);
            return await _futStatsDbContext.SaveChangesAsync();
        }
    }
}
