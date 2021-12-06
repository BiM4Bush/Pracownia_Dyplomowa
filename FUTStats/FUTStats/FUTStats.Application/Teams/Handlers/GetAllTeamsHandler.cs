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
    public class GetAllTeamsHandler: IRequestHandler<GetAllTeamsQuery, QueryResult<IReadOnlyList<TeamEntity>>>
    {
        private readonly ITeamRepository _teamRepository;
        public GetAllTeamsHandler(ITeamRepository teamRepository)
        {
            this._teamRepository = teamRepository;
        }

        public async Task<QueryResult<IReadOnlyList<TeamEntity>>> Handle(GetAllTeamsQuery request, CancellationToken cancellationToken)
        {
            var result = await _teamRepository.GetAllTeams();
            return new QueryResult<IReadOnlyList<TeamEntity>>(true, result, "Successfully got teams");
        }
    }
}
