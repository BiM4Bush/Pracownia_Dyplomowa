using FUTStats.Application.Teams.Commands;
using FUTStats.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FUTStats.Application.Teams.Handlers
{
    public class UpdateTeamHandler: IRequestHandler<UpdateTeamCommand, CommandResult<int>>
    {
        private readonly ITeamRepository _teamRepository;
        public UpdateTeamHandler(ITeamRepository teamRepository)
        {
            this._teamRepository = teamRepository;
        }

        public async Task<CommandResult<int>> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            var data = await _teamRepository.GetTeamAsync(request.Id);
            if(data != null)
            {
                data.Player1Entity = request.teamEntity.Player1Entity;
                data.Player2Entity = request.teamEntity.Player2Entity;
                data.Player3Entity = request.teamEntity.Player3Entity;
                data.Player4Entity = request.teamEntity.Player4Entity;
                data.Player5Entity = request.teamEntity.Player5Entity;
                data.Player6Entity = request.teamEntity.Player6Entity;
                data.Player7Entity = request.teamEntity.Player7Entity;
                data.Player8Entity = request.teamEntity.Player8Entity;
                data.Player9Entity = request.teamEntity.Player9Entity;
                data.Player10Entity = request.teamEntity.Player10Entity;
                data.Player11Entity = request.teamEntity.Player11Entity;
                data.CoachEntity = request.teamEntity.CoachEntity;
                try
                {
                    var result = await _teamRepository.UpdateTeamAsync(data);
                    return new CommandResult<int>(true, result, "Successfully updated team data");
                }
                catch(Exception ex)
                {
                    return new CommandResult<int>(false, 0, ex.Message);
                }
            }
            else
            {
                return new CommandResult<int>(false, 0, "Update failed");
            }
        }
    }
}
