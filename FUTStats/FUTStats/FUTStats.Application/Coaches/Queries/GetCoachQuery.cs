using FUTStats.Infrastructure.Persistance.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Application.Coaches.Queries
{
    public class GetCoachQuery: IRequest<QueryResult<CoachEntity>>
    {
        public Guid Id { get; }
        public GetCoachQuery(Guid id)
        {
            this.Id = id;
        }
    }
}
