using FUTStats.Infrastructure.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FUTStats.Infrastructure.Interfaces
{
    public interface ICoachRepository: IBaseRepository<CoachEntity>
    {
        Task<IReadOnlyList<CoachEntity>> GetAllCoaches();
        Task<CoachEntity> GetCoachAsync(Guid guid);
        Task<int> CreateCoachAsync(CoachEntity entity);
        Task<int> UpdateCoachAsync(CoachEntity entity);
        Task<int> DeleteCoachAsync(CoachEntity entity);
    }
}
