using FUTStats.Infrastructure.Persistance.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Application.Players.Commands
{
    public class UpdatePlayerCommand: IRequest<CommandResult<int>>
    {
        public Guid Id { get; }
        public PlayerEntity playerEntity { get; }
        public UpdatePlayerCommand(Guid id, PlayerEntity player)
        {
            Id = id;
            playerEntity = player;
        }

    }
}
