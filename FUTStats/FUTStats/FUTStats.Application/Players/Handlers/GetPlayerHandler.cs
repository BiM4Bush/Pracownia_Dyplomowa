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
    public class GetPlayerHandler : IRequestHandler<GetPlayerQuery, QueryResult<PlayerEntity>>
    {
        private readonly IPlayerRepository _playerRepository; 
        public GetPlayerHandler(IPlayerRepository playerRepository)
        {
            this._playerRepository = playerRepository;
        }
        public async Task<QueryResult<PlayerEntity>> Handle(GetPlayerQuery request, CancellationToken cancellationToken)
        {
            var result = await _playerRepository.GetPlayerAsync(request.Id);
            return new QueryResult<PlayerEntity>(true, result, "Successfully got player");
        }
    }
}
