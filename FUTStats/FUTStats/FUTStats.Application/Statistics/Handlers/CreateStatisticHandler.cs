using FUTStats.Application.Statistics.Commands;
using FUTStats.Infrastructure.Interfaces;
using FUTStats.Infrastructure.Persistance.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FUTStats.Application.Statistics.Handlers
{
    public class CreateStatisticHandler: IRequestHandler<CreateStatisticCommand, CommandResult<int>>
    {
        private readonly IStatisticRepository _statisticRepository;
        public CreateStatisticHandler(IStatisticRepository statisticRepository)
        {
            this._statisticRepository = statisticRepository;
        }

        public async Task<CommandResult<int>> Handle(CreateStatisticCommand request, CancellationToken cancellationToken)
        {
            var statistic = new StatisticEntity()
            {
                Id = Guid.NewGuid(),
                Goals = request.statisticEntity.Goals,
                Assists = request.statisticEntity.Assists,
                YellowCards = request.statisticEntity.YellowCards,
                RedCards = request.statisticEntity.RedCards,
                PlayerId = request.statisticEntity.PlayerId,
                Player = request.statisticEntity.Player
            };
            try
            {
                var result = await _statisticRepository.CreateStatisticAsync(statistic);
                return new CommandResult<int>(true, result, "Successfully created statistic");
            }
            catch( Exception ex)
            {
                return new CommandResult<int>(false, 0, ex.Message);
            }
        }
    }
}
