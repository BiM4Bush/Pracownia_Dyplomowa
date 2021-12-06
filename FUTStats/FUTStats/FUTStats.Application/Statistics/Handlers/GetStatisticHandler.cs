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
    public class GetStatisticHandler: IRequestHandler<GetStatisticQuery, QueryResult<StatisticEntity>>
    {
        private readonly IStatisticRepository _statisticRepository;
        public GetStatisticHandler(IStatisticRepository statisticRepository)
        {
            this._statisticRepository = statisticRepository;
        }

        public async Task<QueryResult<StatisticEntity>> Handle(GetStatisticQuery request, CancellationToken cancellationToken)
        {
            var result = await _statisticRepository.GetStatisticAsync(request.Id);
            return new QueryResult<StatisticEntity>(true, result, "Successfully got statistic data");
        }
    }
}
