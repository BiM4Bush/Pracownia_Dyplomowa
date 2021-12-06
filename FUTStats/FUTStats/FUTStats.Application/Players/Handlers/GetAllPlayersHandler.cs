using FUTStats.Application.Players.Queries;
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
    public class GetAllPlayersHandler : IRequestHandler<GetAllPlayersQuery, QueryResult<IReadOnlyList<PlayerEntity>>>
    {
        private readonly IPlayerRepository _playerRepository;
        public GetAllPlayersHandler(IPlayerRepository playerRepository)
        {
            this._playerRepository = playerRepository;
        }
        public async Task<QueryResult<IReadOnlyList<PlayerEntity>>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
        {
            var result = await _playerRepository.GetAllPlayers();
            return new QueryResult<IReadOnlyList<PlayerEntity>>(true, result, "Successfully got all players");
        }
    }
}
