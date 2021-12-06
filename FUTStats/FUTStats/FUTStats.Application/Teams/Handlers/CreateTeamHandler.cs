using FUTStats.Application.Teams.Commands;
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
    public class CreateTeamHandler: IRequestHandler<CreateTeamCommand, CommandResult<int>>
    {
        private readonly ITeamRepository _teamRepository;
        public CreateTeamHandler(ITeamRepository teamRepository)
        {
            this._teamRepository = teamRepository;
        }

        public async Task<CommandResult<int>> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var team = new TeamEntity()
            {
                Id = Guid.NewGuid(),
                Player1Entity = request.teamEntity.Player1Entity,
                Player2Entity = request.teamEntity.Player2Entity,
                Player3Entity = request.teamEntity.Player3Entity,
                Player4Entity = request.teamEntity.Player4Entity,
                Player5Entity = request.teamEntity.Player5Entity,
                Player6Entity = request.teamEntity.Player6Entity,
                Player7Entity = request.teamEntity.Player7Entity,
                Player8Entity = request.teamEntity.Player8Entity,
                Player9Entity = request.teamEntity.Player9Entity,
                Player10Entity = request.teamEntity.Player10Entity,
                Player11Entity = request.teamEntity.Player11Entity,
                CoachEntity = request.teamEntity.CoachEntity
            };
            try
            {
                var result = await _teamRepository.CreateTeamAsync(team);
                return new CommandResult<int>(true, result, "Successfully created team");
            }
            catch(Exception ex)
            {
                return new CommandResult<int>(false, 0, ex.Message);
            }
        }
    }
}
