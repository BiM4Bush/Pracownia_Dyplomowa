using FUTStats.Infrastructure.Persistance.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Application.Statistics.Queries
{
    public class GetAllStatisticsQuery: IRequest<QueryResult<IReadOnlyList<StatisticEntity>>>
    {
        public GetAllStatisticsQuery()
        {

        }
    }
}
