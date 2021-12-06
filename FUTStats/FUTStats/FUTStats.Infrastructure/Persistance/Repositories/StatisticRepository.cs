using FUTStats.Infrastructure.Interfaces;
using FUTStats.Infrastructure.Persistance.DbContexts;
using FUTStats.Infrastructure.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUTStats.Infrastructure.Persistance.Repositories
{
    public class StatisticRepository : BaseRepository<PlayerEntity>, IStatisticRepository
    {
        protected readonly FutStatsDbContext _futStatsDbContext;
        public StatisticRepository(FutStatsDbContext futStatsDbContext): base(futStatsDbContext)
        {
            this._futStatsDbContext = futStatsDbContext;
        }

        public async Task<int> CreateStatisticAsync(StatisticEntity entity)
        {
            await _futStatsDbContext.Set<StatisticEntity>().AddAsync(entity);
            return await _futStatsDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteStatisticAsync(StatisticEntity entity)
        {
            _futStatsDbContext.Set<StatisticEntity>().Remove(entity);
            return await _futStatsDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<StatisticEntity>> GetAllStatistics()
        {
            return await _futStatsDbContext.Set<StatisticEntity>().ToListAsync();
        }

        public async Task<StatisticEntity> GetStatisticAsync(Guid guid)
        {
            return await _futStatsDbContext.Set<StatisticEntity>().FindAsync(guid);
        }

        public async Task<int> UpdateStatisticAsync(StatisticEntity entity)
        {
            _futStatsDbContext.Set<StatisticEntity>().Update(entity);
            return await _futStatsDbContext.SaveChangesAsync();
        }

        IQueryable<StatisticEntity> IBaseRepository<StatisticEntity>.FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
