using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Application.Players.Commands
{
    public class DeletePlayerCommand: IRequest<CommandResult<int>>
    {
        public Guid Id { get; }
        public DeletePlayerCommand(Guid id)
        {
            Id = id;
        }
    }
}
