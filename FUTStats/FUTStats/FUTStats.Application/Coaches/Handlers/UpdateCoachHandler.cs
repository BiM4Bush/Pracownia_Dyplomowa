using FUTStats.Application.Coaches.Commands;
using FUTStats.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FUTStats.Application.Coaches.Handlers
{
    public class UpdateCoachHandler : IRequestHandler<UpdateCoachCommand, CommandResult<int>>
    {
        private readonly ICoachRepository _coachRepository;
        public UpdateCoachHandler(ICoachRepository coachRepository)
        {
            this._coachRepository = coachRepository;
        }
        public async Task<CommandResult<int>> Handle(UpdateCoachCommand request, CancellationToken cancellationToken)
        {
            var data = await _coachRepository.GetCoachAsync(request.Id);
            if(data != null)
            {
                data.TeamId = request.coachEntity.TeamId;
                data.Team = request.coachEntity.Team;
                try
                {
                    var result = await _coachRepository.UpdateCoachAsync(data);
                    return new CommandResult<int>(true, result, "Successfully updated coach");
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
