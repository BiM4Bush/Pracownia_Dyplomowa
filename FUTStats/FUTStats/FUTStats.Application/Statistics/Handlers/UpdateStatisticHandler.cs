using FUTStats.Application.Statistics.Commands;
using FUTStats.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FUTStats.Application.Statistics.Handlers
{
    public class UpdateStatisticHandler: IRequestHandler<UpdateStatisticCommand, CommandResult<int>>
    {
        private readonly IStatisticRepository _statisticRepository;
        public UpdateStatisticHandler(IStatisticRepository statisticRepository)
        {
            this._statisticRepository = statisticRepository;
        }

        public async Task<CommandResult<int>> Handle(UpdateStatisticCommand request, CancellationToken cancellationToken)
        {
            var data = await _statisticRepository.GetStatisticAsync(request.Id);
            if(data != null)
            {
                data.Goals = request.statisticEntity.Goals;
                data.Assists = request.statisticEntity.Assists;
                data.YellowCards = request.statisticEntity.YellowCards;
                data.RedCards = request.statisticEntity.RedCards;
            }
            try
            {
                var result = await _statisticRepository.UpdateStatisticAsync(data);
                return new CommandResult<int>(true, result, "Successfully updated statistic");
            }
            catch(Exception ex)
            {
                return new CommandResult<int>(false, 0, ex.Message);
            }
        }
    }
}
