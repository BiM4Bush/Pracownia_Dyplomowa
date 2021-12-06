using FUTStats.Infrastructure.Persistance.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Application.Teams.Commands
{
    public class UpdateTeamCommand: IRequest<CommandResult<int>>
    {
        public Guid Id { get; }
        public TeamEntity teamEntity { get; }
        public UpdateTeamCommand(Guid id, TeamEntity team)
        {
            this.Id = id;
            this.teamEntity = team;
        }
    }
}
