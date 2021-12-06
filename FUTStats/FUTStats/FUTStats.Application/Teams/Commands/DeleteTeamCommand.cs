using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Application.Teams.Commands
{
    public class DeleteTeamCommand: IRequest<CommandResult<int>>
    {
        public Guid Id { get; }
        public DeleteTeamCommand(Guid id)
        {
            this.Id = id;
        }
    }
}
