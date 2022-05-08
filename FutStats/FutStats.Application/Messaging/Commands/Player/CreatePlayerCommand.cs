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

namespace FutStats.Application.Messaging.Commands.Player
{
    public class CreatePlayerCommand : ICommand<Unit>
    {
        public string Name { get; }
        public string Surname { get; }
        public int KitNumber { get; }
        public Positions Position { get; }

        public CreatePlayerCommand(string name, string surname, int kitNumber, Positions position)
        {
            Name = name;
            Surname = surname;
            KitNumber = kitNumber;
            Position = position;
        }

        public class Validator : AbstractValidator<CreatePlayerCommand>
        {
            public Validator()
            {
                RuleFor(p => p.Name.Length).GreaterThanOrEqualTo(3).LessThanOrEqualTo(50);
                RuleFor(p => p.Surname.Length).GreaterThanOrEqualTo(3).LessThanOrEqualTo(50);
                RuleFor(p => p.Position).IsInEnum();
                RuleFor(p => p.KitNumber).GreaterThanOrEqualTo(1).LessThanOrEqualTo(99);
            }
        }

        public class Handler : ICommandHandler<CreatePlayerCommand, Unit>
        {
            private readonly IPlayerRepository _playerRepository;
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IPlayerRepository playerRepository, IUnitOfWork unitOfWork)
            {
                _playerRepository = playerRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Unit> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
            {
                var player = new PlayerEntity
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    Surname = request.Surname,
                    KitNumber = request.KitNumber,
                    Position = request.Position
                };

                _playerRepository.Add(player);
                await _unitOfWork.Complete(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
