using FUTStats.Infrastructure.Persistance.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Application.Coaches.Commands
{
    public class CreateCoachCommand: IRequest<CommandResult<int>>
    {
        public CoachEntity coachEntity { get; }
        public CreateCoachCommand(CoachEntity coach)
        {
            this.coachEntity = coach;
        }
    }
}
