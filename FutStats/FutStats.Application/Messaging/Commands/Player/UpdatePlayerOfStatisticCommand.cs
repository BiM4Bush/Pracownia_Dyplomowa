using FutStats.Application.Messaging.Abstractions;
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
    public class UpdatePlayerOfStatisticCommand : ICommand<Unit>
    {
        public Guid StatisticId { get; }
        public Guid PlayerId { get; }

        public UpdatePlayerOfStatisticCommand(Guid statisticId, Guid playerId)
        {
            StatisticId = statisticId;
            PlayerId = playerId;
        }

        public class Handler : ICommandHandler<UpdatePlayerOfStatisticCommand, Unit>
        {
            private readonly IPlayerRepository _playerRepository;
            private readonly IStatisticRepository _statisticRepository;
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IPlayerRepository playerRepository, IStatisticRepository statisticRepository, IUnitOfWork unitOfWork)
            {
                _playerRepository = playerRepository;
                _statisticRepository = statisticRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Unit> Handle(UpdatePlayerOfStatisticCommand request, CancellationToken cancellationToken)
            {
                var statistic = await _statisticRepository.GetSingle(p => p.Id == request.StatisticId, cancellationToken);
                if (statistic is null)
                {
                    throw new ArgumentNullException($"Statistic with id = {request.StatisticId} does not exist");
                }

                var player = await _playerRepository.GetSingle(p => p.Id == request.PlayerId, cancellationToken);
                if (player is null)
                {
                    throw new ArgumentNullException($"Player with id = {request.PlayerId} does not exist");
                }

                player.StatisticEntityId = statistic.Id;
                player.StatisticEntity = statistic;

                statistic.PlayerId = player.Id;
                statistic.Player = player;

                await _unitOfWork.Complete(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
