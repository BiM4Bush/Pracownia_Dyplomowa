using FUTStats.Application.Statistics.Queries;
using FUTStats.Infrastructure.Interfaces;
using FUTStats.Infrastructure.Persistance.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FUTStats.Application.Statistics.Handlers
{
    public class GetAllStatisticsHandler : IRequestHandler<GetAllStatisticsQuery, QueryResult<IReadOnlyList<StatisticEntity>>>
    {
        private readonly IStatisticRepository _statisticRepository;
        public GetAllStatisticsHandler(IStatisticRepository statisticRepository)
        {
            this._statisticRepository = statisticRepository;
        }
        public async Task<QueryResult<IReadOnlyList<StatisticEntity>>> Handle(GetAllStatisticsQuery request, CancellationToken cancellationToken)
        {
            var result = await _statisticRepository.GetAllStatistics();
            return new QueryResult<IReadOnlyList<StatisticEntity>>(true, result, "Successfully got all statistics");
        }
    }
}
