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
    public class DeleteStatisticHandler: IRequestHandler<DeleteStatisticCommand, CommandResult<int>>
    {
        private readonly IStatisticRepository _statisticRepository;
        public DeleteStatisticHandler(IStatisticRepository statisticRepository)
        {
            this._statisticRepository = statisticRepository;
        }

        public async Task<CommandResult<int>> Handle(DeleteStatisticCommand request, CancellationToken cancellationToken)
        {
            var statistic = await _statisticRepository.GetStatisticAsync(request.Id);
            if (statistic != null)
            {
                try
                {
                    var result = await _statisticRepository.DeleteStatisticAsync(statistic);
                    return new CommandResult<int>(true, result, "Successfully deleted statistic");
                }
                catch(Exception ex)
                {
                    return new CommandResult<int>(false, 0, ex.Message);
                }
            }
            else
            {
                var message = "Delete failed";
                return new CommandResult<int>(false, 0, message);
            }
        }
    }
}
