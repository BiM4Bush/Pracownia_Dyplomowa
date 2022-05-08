using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FutStats.Application.Messaging.Abstractions;
using FutStats.Domain.Repositories;
using FutStats.Domain.Repositories.Entities;
using MediatR;

namespace FutStats.Application.Messaging.Commands.Team
{
    public class HireCoachCommand : ICommand<Unit>
    {
        public Guid TeamId { get; }
        public Guid CoachId { get; }
        public string CoachName { get; }
        public string CoachSurname { get; }

        public HireCoachCommand(Guid teamId, Guid coachId, string coachName, string coachSurname)
        {
            TeamId = teamId;
            CoachId = coachId;
            CoachName = coachName;
            CoachSurname = coachSurname;
        }

        public class Handler : ICommandHandler<HireCoachCommand, Unit>
        {
            private readonly ITeamRepository _teamRepository;
            private readonly ICoachRepository _coachRepository;
            private readonly IUnitOfWork _unitOfWork;

            public Handler(ITeamRepository teamRepository, ICoachRepository coachRepository, IUnitOfWork unitOfWork)
            {
                _teamRepository = teamRepository;
                _coachRepository = coachRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Unit> Handle(HireCoachCommand request, CancellationToken cancellationToken)
            {
                var team = await _teamRepository.GetSingle(p => p.Id == request.TeamId, cancellationToken);
                if (team is null)
                {
                    throw new ArgumentNullException($"Team with id = {request.TeamId} does not exist");
                }

                var coach = await _coachRepository.GetSingle(p => p.Id == request.CoachId && p.Name == request.CoachName && p.Surname == request.CoachSurname, cancellationToken);
                if (coach is null)
                {
                    throw new ArgumentNullException($"Coach with id = {request.CoachId}, name = {request.CoachName} {request.CoachSurname} does not exist");
                }


                coach.TeamId = request.TeamId;
                coach.Team = team;

                team.Coach = coach;

                await _unitOfWork.Complete(cancellationToken);
                return Unit.Value;

            }
        }
    }
}
