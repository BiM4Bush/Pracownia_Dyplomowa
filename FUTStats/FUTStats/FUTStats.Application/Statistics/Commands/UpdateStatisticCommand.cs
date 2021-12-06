using FUTStats.Infrastructure.Persistance.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Application.Statistics.Commands
{
    public class UpdateStatisticCommand: IRequest<CommandResult<int>>
    {
        public Guid Id { get; }
        public StatisticEntity statisticEntity { get; }
        public UpdateStatisticCommand(Guid id, StatisticEntity statistic)
        {
            Id = id;
            statisticEntity = statistic;
        }
    }
}
