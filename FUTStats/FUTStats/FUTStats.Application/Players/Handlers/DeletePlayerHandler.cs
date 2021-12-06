using FUTStats.Application.Players.Commands;
using FUTStats.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FUTStats.Application.Players.Handlers
{
    public class DeletePlayerHandler : IRequestHandler<DeletePlayerCommand, CommandResult<int>>
    {
        private readonly IPlayerRepository _playerRepository;
        public DeletePlayerHandler(IPlayerRepository playerRepository)
        {
            this._playerRepository = playerRepository;
        }
        public async Task<CommandResult<int>> Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = await _playerRepository.GetPlayerAsync(request.Id);
            if(player != null)
            {
                try
                {
                    var result = await _playerRepository.DeletePlayerAsync(player);
                    return new CommandResult<int>(true, result, "Successfully deleted player");
                }
                catch(Exception ex)
                {
                    return new CommandResult<int>(false, 0, ex.Message);
                }
            }
            else
            {
                var message = "Delete failed";
                return new CommandResult<int>(false, 0, message);
            }
        }
    }
}
