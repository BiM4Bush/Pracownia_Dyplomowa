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
    public class DeleteTeamHandler: IRequestHandler<DeleteTeamCommand, CommandResult<int>>
    {
        private readonly ITeamRepository _teamRepository;
        public DeleteTeamHandler(ITeamRepository teamRepository)
        {
            this._teamRepository = teamRepository;
        }

        public async Task<CommandResult<int>> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            var team = await _teamRepository.GetTeamAsync(request.Id);
            if(team != null)
            {
                try
                {
                    var result = await _teamRepository.DeleteTeamAsync(team);
                    return new CommandResult<int>(true, result, "Successfully deleted team");
                }
                catch(Exception ex)
                {
                    return new CommandResult<int>(false, 0, ex.Message);
                }
            }
            else
            {
                return new CommandResult<int>(false, 0, "Delete failed");
            }
        }
    }
}
