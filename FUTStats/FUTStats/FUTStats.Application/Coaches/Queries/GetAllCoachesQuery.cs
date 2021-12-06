using FUTStats.Infrastructure.Persistance.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Application.Coaches.Queries
{
    public class GetAllCoachesQuery: IRequest<QueryResult<IReadOnlyList<CoachEntity>>>
    {
        public GetAllCoachesQuery()
        {

        }
    }
}
