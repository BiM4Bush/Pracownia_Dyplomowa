using FUTStats.Infrastructure.Persistance.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Application.Teams.Queries
{
    public class GetAllTeamsQuery: IRequest<QueryResult<IReadOnlyList<TeamEntity>>>
    {
        public GetAllTeamsQuery()
        {

        }
    }
}
