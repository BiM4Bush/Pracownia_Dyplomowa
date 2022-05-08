using FluentValidation;
using FutStats.Application.Messaging.Abstractions;
using FutStats.Domain.Entities;
using FutStats.Domain.Enums;
using FutStats.Domain.Repositories;
using FutStats.Domain.Repositories.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FutStats.Application.Messaging.Commands
{
    public class CreateCoachCommand : ICommand<Unit>
    {
        public string Name { get; }
        public string Surname { get; }
        public Nationalities Nationality { get; }

        public CreateCoachCommand(string name, string surname, Nationalities nationality)
        {
            Name = name;
            Surname = surname;
            Nationality = nationality;
        }

        public class Validator : AbstractValidator<CreateCoachCommand>
        {
            public Validator()
            {
                RuleFor(p => p.Name.Length).GreaterThanOrEqualTo(3).LessThanOrEqualTo(50);
                RuleFor(p => p.Surname.Length).GreaterThanOrEqualTo(3).LessThanOrEqualTo(50);
                RuleFor(p => p.Nationality).IsInEnum();
            }
        }

        public class Handler : ICommandHandler<CreateCoachCommand, Unit>
        {
            private readonly ICoachRepository _coachRepository;
            private readonly IUnitOfWork _unitOfWork;

            public Handler(ICoachRepository coachRepository, IUnitOfWork unitOfWork)
            {
                _coachRepository = coachRepository ?? throw new ArgumentNullException(nameof(coachRepository));
                _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            }

            public async Task<Unit> Handle(CreateCoachCommand request, CancellationToken cancellationToken)
            {
                var coach = new CoachEntity
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    Surname = request.Surname,
                    Nationality = request.Nationality,
                };

                _coachRepository.Add(coach);
                await _unitOfWork.Complete(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
