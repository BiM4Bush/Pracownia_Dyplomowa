using FUTStats.Infrastructure.Persistance.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Application.Players.Queries
{
    public class GetAllPlayersQuery: IRequest<QueryResult<IReadOnlyList<PlayerEntity>>>
    {
        public GetAllPlayersQuery()
        {

        }
    }
}
