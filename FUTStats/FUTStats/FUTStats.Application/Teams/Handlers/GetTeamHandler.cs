using FUTStats.Application.Teams.Queries;
using FUTStats.Infrastructure.Interfaces;
using FUTStats.Infrastructure.Persistance.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FUTStats.Application.Teams.Handlers
{
    public class GetTeamHandler: IRequestHandler<GetTeamQuery, QueryResult<TeamEntity>>
    {
        private readonly ITeamRepository _teamRepository;
        public GetTeamHandler(ITeamRepository teamRepository)
        {
            this._teamRepository = teamRepository;        }

        public async Task<QueryResult<TeamEntity>> Handle(GetTeamQuery request, CancellationToken cancellationToken)
        {
            var result = await _teamRepository.GetTeamAsync(request.Id);
            return new QueryResult<TeamEntity>(true, result, "Successfully got team data");
        }
    }
}
