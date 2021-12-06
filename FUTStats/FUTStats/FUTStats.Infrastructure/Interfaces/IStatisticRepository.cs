using FUTStats.Infrastructure.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FUTStats.Infrastructure.Interfaces
{
    public interface IStatisticRepository: IBaseRepository<StatisticEntity>
    {
        Task<IReadOnlyList<StatisticEntity>> GetAllStatistics();
        Task<StatisticEntity> GetStatisticAsync(Guid guid);
        Task<int> CreateStatisticAsync(StatisticEntity entity);
        Task<int> UpdateStatisticAsync(StatisticEntity entity);
        Task<int> DeleteStatisticAsync(StatisticEntity entity);
    }
}
