using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FutStats.Application.Messaging.Abstractions;
using FutStats.Domain.Entities;
using FutStats.Domain.Repositories;
using FutStats.Domain.Repositories.Entities;
using MediatR;

namespace FutStats.Application.Messaging.Commands.Team
{
    public class CreateTeamCommand : ICommand<Unit>
    {
        public string Name { get; set; }
        public int Week { get; set; }

        public CreateTeamCommand(string name, int week)
        {
            Name = name;
            Week = week;
        }

        public class Validator : AbstractValidator<CreateTeamCommand>
        {
            public Validator()
            {
                RuleFor(p => p.Name.Length).GreaterThanOrEqualTo(3).LessThanOrEqualTo(50);
                RuleFor(p => p.Week).GreaterThanOrEqualTo(1);
            }
        }

        public class Handler : ICommandHandler<CreateTeamCommand, Unit>
        {
            private readonly ITeamRepository _teamRepository;
            private readonly IUnitOfWork _unitOfWork;

            public Handler(ITeamRepository teamRepository, IUnitOfWork unitOfWork)
            {
                _teamRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
                _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            }

            public async Task<Unit> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
            {
                var team = new TeamEntity
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    Week = request.Week
                };

                _teamRepository.Add(team);
                await _unitOfWork.Complete(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
