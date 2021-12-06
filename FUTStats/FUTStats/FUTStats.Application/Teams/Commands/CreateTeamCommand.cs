using FUTStats.Infrastructure.Persistance.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Application.Teams.Commands
{
    public class CreateTeamCommand: IRequest<CommandResult<int>>
    {
        public TeamEntity teamEntity { get; }
        public CreateTeamCommand(TeamEntity team)
        {
            this.teamEntity = team;
        }
    }
}
