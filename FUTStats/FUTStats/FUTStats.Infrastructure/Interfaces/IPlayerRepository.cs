using FUTStats.Infrastructure.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FUTStats.Infrastructure.Interfaces
{
    public interface IPlayerRepository: IBaseRepository<PlayerEntity>
    {
        Task<IReadOnlyList<PlayerEntity>> GetAllPlayers();
        Task<PlayerEntity> GetPlayerAsync(Guid guid);
        Task<int> CreatePlayerAsync(PlayerEntity entity);
        Task<int> UpdatePlayerAsync(PlayerEntity entity);
        Task<int> DeletePlayerAsync(PlayerEntity entity);
    }
}
