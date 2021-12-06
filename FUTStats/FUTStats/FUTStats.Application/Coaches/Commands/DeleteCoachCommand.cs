using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Application.Coaches.Commands
{
    public class DeleteCoachCommand: IRequest<CommandResult<int>>
    {
        public Guid Id { get; }
        public DeleteCoachCommand(Guid id)
        {
            this.Id = id;
        }
    }
}
