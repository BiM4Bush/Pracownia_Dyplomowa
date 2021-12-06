using FUTStats.Application.Coaches.Commands;
using FUTStats.Infrastructure.Interfaces;
using FUTStats.Infrastructure.Persistance.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FUTStats.Application.Coaches.Handlers
{
    public class CreateCoachHandler : IRequestHandler<CreateCoachCommand, CommandResult<int>>
    {
        private readonly ICoachRepository _coachRepository;
        public CreateCoachHandler(ICoachRepository coachRepository)
        {
            this._coachRepository = coachRepository;
        }
        public async Task<CommandResult<int>> Handle(CreateCoachCommand request, CancellationToken cancellationToken)
        {
            var coach = new CoachEntity()
            {
                Id = Guid.NewGuid(),
                Name = request.coachEntity.Name,
                Surname = request.coachEntity.Surname,
                Nationality = request.coachEntity.Nationality,
                TeamId = request.coachEntity.TeamId,
                Team = request.coachEntity.Team,
            };
            try
            {
                var result = await _coachRepository.CreateCoachAsync(coach);
                return new CommandResult<int>(true, result, "Successfully created coach");
            }
            catch(Exception ex)
            {
                return new CommandResult<int>(false, 0, ex.Message);
            }
        }
    }
}
