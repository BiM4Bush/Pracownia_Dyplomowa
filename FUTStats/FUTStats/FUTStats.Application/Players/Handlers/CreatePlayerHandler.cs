using FUTStats.Application.Players.Commands;
using FUTStats.Infrastructure.Interfaces;
using FUTStats.Infrastructure.Persistance.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FUTStats.Application.Players.Handlers
{
    public class CreatePlayerHandler : IRequestHandler<CreatePlayerCommand, CommandResult<int>>
    {
        private readonly IPlayerRepository _playerRepository;
        public CreatePlayerHandler(IPlayerRepository playerRepository)
        {
            this._playerRepository = playerRepository;
        }
        public async Task<CommandResult<int>> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = new PlayerEntity()
            {
                Id = Guid.NewGuid(),
                Name = request.playerEntity.Name,
                Surname = request.playerEntity.Surname,
                KitNumber = request.playerEntity.KitNumber,
                Position = request.playerEntity.Position,
                StatisticEntity = request.playerEntity.StatisticEntity,
                TeamId = request.playerEntity.TeamId,
                Team = request.playerEntity.Team
            };
            try
            {
                var result = await _playerRepository.CreatePlayerAsync(player);
                return new CommandResult<int>(true, result, "Successfully created player");
            }
            catch(Exception ex)
            {
                return new CommandResult<int>(false, 0, ex.Message);
            }

        }
    }
}
