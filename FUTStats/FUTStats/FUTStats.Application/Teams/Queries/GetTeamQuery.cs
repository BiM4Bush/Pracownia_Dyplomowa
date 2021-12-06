using FUTStats.Infrastructure.Persistance.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Application.Teams.Queries
{
    public class GetTeamQuery: IRequest<QueryResult<TeamEntity>>
    {
        public Guid Id { get; }
        public GetTeamQuery(Guid id)
        {
            this.Id = id;
        }
    }
}
