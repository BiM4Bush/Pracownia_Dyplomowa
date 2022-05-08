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
    public class SignPlayerCommand : ICommand<Unit>
    {
        public Guid TeamId { get; }
        public Guid PlayerId { get; }
        public string PlayerName { get; }
        public string PlayerSurname { get; }

        public SignPlayerCommand(Guid teamId, Guid playerId, string playerName, string playerSurname)
        {
            TeamId = teamId;
            PlayerId = playerId;
            PlayerName = playerName;
            PlayerSurname = playerSurname;
        }

        public class Handler : ICommandHandler<SignPlayerCommand, Unit>
        {
            private readonly ITeamRepository _teamRepository;
            private readonly IPlayerRepository _playerRepository;
            private readonly IUnitOfWork _unitOfWork;

            public Handler(ITeamRepository teamRepository, IPlayerRepository playerRepository, IUnitOfWork unitOfWork)
            {
                _teamRepository = teamRepository;
                _playerRepository = playerRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Unit> Handle(SignPlayerCommand request, CancellationToken cancellationToken)
            {
                var team = await _teamRepository.ReadSingle(p => p.Id == request.TeamId, cancellationToken);
                if (team is null)
                {
                    throw new ArgumentNullException($"Team with id = {request.TeamId} does not exist");
                }

                var player = await _playerRepository.GetSingle(
                    p => p.Id == request.PlayerId && p.Name == request.PlayerName && p.Surname == request.PlayerSurname,
                    cancellationToken);
                if (player is null)
                {
                    throw new ArgumentNullException($"Player with id = {request.PlayerId} and name = {request.PlayerName} {request.PlayerSurname} does not exist");
                }

                player.TeamId = team.Id;
                player.Team = team;

                await _unitOfWork.Complete(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
