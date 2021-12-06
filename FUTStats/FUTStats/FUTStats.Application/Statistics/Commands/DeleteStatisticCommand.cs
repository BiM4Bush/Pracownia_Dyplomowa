using FUTStats.Infrastructure.Persistance.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Application.Statistics.Commands
{
    public class DeleteStatisticCommand: IRequest<CommandResult<int>>
    {
        public Guid Id { get; }
        public DeleteStatisticCommand(Guid id)
        {
            Id = id;
        }
    }
}