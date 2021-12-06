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
    public class UpdatePlayerHandler : IRequestHandler<UpdatePlayerCommand, CommandResult<int>>
    {
        private readonly IPlayerRepository _playerRepository;
        public UpdatePlayerHandler(IPlayerRepository playerRepository)
        {
            this._playerRepository = playerRepository;
        }
        public async Task<CommandResult<int>> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
        {
            var data = await _playerRepository.GetPlayerAsync(request.Id);
            if(data != null)
            { 
                data.KitNumber = request.playerEntity.KitNumber;
                data.Position = request.playerEntity.Position;
                data.StatisticEntity = request.playerEntity.StatisticEntity ?? data.StatisticEntity;
            }
            try
            {
                var result = await _playerRepository.UpdatePlayerAsync(data);
                return new CommandResult<int>(true, result, "Successfully updated player's data");
            }
            catch (Exception ex)
            {
                return new CommandResult<int>(false, 0, ex.Message);
            }
        }
    }
}
