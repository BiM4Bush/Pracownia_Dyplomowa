using FUTStats.Infrastructure.Persistance.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Application.Statistics.Commands
{
    public class CreateStatisticCommand: IRequest<CommandResult<int>>
    {
        public StatisticEntity statisticEntity { get; }
        public CreateStatisticCommand(StatisticEntity statistic)
        {
            statisticEntity = statistic;
        }

    }
}
