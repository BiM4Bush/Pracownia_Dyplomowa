using FUTStats.Infrastructure.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FUTStats.Infrastructure.Interfaces
{
    public interface ITeamRepository: IBaseRepository<TeamEntity>
    {
        Task<IReadOnlyList<TeamEntity>> GetAllTeams();
        Task<TeamEntity> GetTeamAsync(Guid guid);
        Task<int> CreateTeamAsync(TeamEntity entity);
        Task<int> UpdateTeamAsync(TeamEntity entity);
        Task<int> DeleteTeamAsync(TeamEntity entity);
    }
}
