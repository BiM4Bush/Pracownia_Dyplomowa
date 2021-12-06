using FUTStats.Infrastructure.Persistance.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Application.Statistics.Queries
{
    public class GetStatisticQuery: IRequest<QueryResult<StatisticEntity>>
    {
        public Guid Id { get; }
        public GetStatisticQuery(Guid id)
        {
            Id = id;
        }
    }
}
