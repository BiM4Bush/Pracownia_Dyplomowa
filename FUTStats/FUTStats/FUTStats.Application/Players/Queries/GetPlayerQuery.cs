using FUTStats.Infrastructure.Persistance.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Application.Players.Queries
{
    public class GetPlayerQuery: IRequest<QueryResult<PlayerEntity>>
    {
        public Guid Id { get; }
        public GetPlayerQuery(Guid id)
        {
            Id = id;
        }
    }
}
