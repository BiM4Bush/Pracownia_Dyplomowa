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
    public class PlayerRepository : BaseRepository<PlayerEntity>, IPlayerRepository
    {
        protected readonly FutStatsDbContext _futStatsDbContext;
        public PlayerRepository(FutStatsDbContext futStatsDbContext): base(futStatsDbContext)
        {
            this._futStatsDbContext = futStatsDbContext;
        }
        public async Task<int> CreatePlayerAsync(PlayerEntity entity)
        {
            await _futStatsDbContext.Set<PlayerEntity>().AddAsync(entity);
            return await _futStatsDbContext.SaveChangesAsync();
        }

        public async Task<int> DeletePlayerAsync(PlayerEntity entity)
        {
            _futStatsDbContext.Set<PlayerEntity>().Remove(entity);
            return await _futStatsDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<PlayerEntity>> GetAllPlayers()
        {
            return await _futStatsDbContext.Set<PlayerEntity>().ToListAsync();
        }

        public async Task<PlayerEntity> GetPlayerAsync(Guid guid)
        {
            return await _futStatsDbContext.Set<PlayerEntity>().FindAsync(guid);
        }

        public async Task<int> UpdatePlayerAsync(PlayerEntity entity)
        {
            _futStatsDbContext.Set<PlayerEntity>().Update(entity);
            return await _futStatsDbContext.SaveChangesAsync();
        }
    }
}
