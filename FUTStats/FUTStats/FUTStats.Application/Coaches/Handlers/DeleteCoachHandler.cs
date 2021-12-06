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
    public class DeleteCoachHandler : IRequestHandler<DeleteCoachCommand, CommandResult<int>>
    {
        private readonly ICoachRepository _coachRepository;
        public DeleteCoachHandler(ICoachRepository coachRepository)
        {
            this._coachRepository = coachRepository;
        }
        public async Task<CommandResult<int>> Handle(DeleteCoachCommand request, CancellationToken cancellationToken)
        {
            var coach = await _coachRepository.GetCoachAsync(request.Id);
            if(coach != null)
            {
                try
                {
                    var result = await _coachRepository.DeleteCoachAsync(coach);
                    return new CommandResult<int>(true, result, "Succesfully deleted coach");
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
