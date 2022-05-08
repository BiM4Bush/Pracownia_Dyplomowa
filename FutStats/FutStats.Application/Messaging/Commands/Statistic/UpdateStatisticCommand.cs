using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FutStats.Application.Messaging.Abstractions;
using FutStats.Domain.Repositories;
using FutStats.Domain.Repositories.Entities;
using MediatR;

namespace FutStats.Application.Messaging.Commands.Statistic
{
    public class UpdateStatisticCommand : ICommand<Unit>
    {
        public Guid StatisticId { get; set; }
        public int? Goals { get; set; }

        public int? Assists { get; set; }

        public int? YellowCards { get; set; }

        public int? RedCards { get; set; }

        public UpdateStatisticCommand(Guid statisticId, int? goals, int? assists, int? yellowCards, int? redCards)
        {
            StatisticId = statisticId;
            Goals = goals;
            Assists = assists;
            YellowCards = yellowCards;
            RedCards = redCards;
        }

        public class Handler : ICommandHandler<UpdateStatisticCommand, Unit>
        {
            private readonly IStatisticRepository _statisticRepository;
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IStatisticRepository statisticRepository, IUnitOfWork unitOfWork)
            {
                _statisticRepository = statisticRepository ?? throw new ArgumentNullException(nameof(statisticRepository));
                _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            }
            public async Task<Unit> Handle(UpdateStatisticCommand request, CancellationToken cancellationToken)
            {
                var statistic = await _statisticRepository.GetSingle(p => p.Id == request.StatisticId, cancellationToken);
                if (statistic == null)
                {
                    throw new ArgumentNullException($"Statistic with id = {request.StatisticId} does not exists");
                }

                if (request.Goals.HasValue)
                {
                    statistic.Goals = request.Goals.Value;
                }

                if (request.Assists.HasValue)
                {
                    statistic.Assists = request.Assists.Value;
                }

                if (request.YellowCards.HasValue)
                {
                    statistic.YellowCards = request.YellowCards.Value;
                }
                if (request.RedCards.HasValue)
                {
                    statistic.RedCards = request.RedCards.Value;
                }

                await _unitOfWork.Complete(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
