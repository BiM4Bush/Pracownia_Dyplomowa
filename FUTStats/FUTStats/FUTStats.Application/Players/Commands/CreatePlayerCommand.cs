using FUTStats.Infrastructure.Persistance.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Application.Players.Commands
{
    public class CreatePlayerCommand: IRequest<CommandResult<int>>
    {
        public PlayerEntity playerEntity { get; }
        public CreatePlayerCommand(PlayerEntity player)
        {
            playerEntity = player;
        }
    }
}
