using FUTStats.Infrastructure.Persistance.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Application.Coaches.Commands
{
    public class UpdateCoachCommand: IRequest<CommandResult<int>>
    {
        public Guid Id { get; }
        public CoachEntity coachEntity { get; }
        public UpdateCoachCommand(Guid id, CoachEntity coach)
        {
            this.coachEntity = coach;
            this.Id = id;
        }
    }
}
