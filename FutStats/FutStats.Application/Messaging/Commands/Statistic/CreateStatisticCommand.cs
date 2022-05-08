using FluentValidation;
using FutStats.Application.Messaging.Abstractions;
using FutStats.Domain.Entities;
using FutStats.Domain.Repositories;
using FutStats.Domain.Repositories.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FutStats.Application.Messaging.Commands.Statistic
{
    public class CreateStatisticCommand : ICommand<Unit>
    {
        public int Goals { get; }

        public int Assists { get; }

        public int YellowCards { get; }

        public int RedCards { get; }

        public CreateStatisticCommand(int goals, int assists, int yellowCards, int redCards)
        {
            Goals = goals;
            Assists = assists;
            YellowCards = yellowCards;
            RedCards = redCards;
        }

        public class Validator : AbstractValidator<CreateStatisticCommand>
        {
            public Validator()
            {
                RuleFor(p => p.Goals).GreaterThanOrEqualTo(0);
                RuleFor(p => p.Assists).GreaterThanOrEqualTo(0);
                RuleFor(p => p.YellowCards).GreaterThanOrEqualTo(0);
                RuleFor(p => p.RedCards).GreaterThanOrEqualTo(0);
            }
        }

        public class Handler : ICommandHandler<CreateStatisticCommand, Unit>
        {
            private readonly IStatisticRepository _statisticRepository;
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IStatisticRepository statisticRepository, IUnitOfWork unitOfWork)
            {
                _statisticRepository = statisticRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Unit> Handle(CreateStatisticCommand request, CancellationToken cancellationToken)
            {
                var statistic = new StatisticEntity
                {
                    Id = Guid.NewGuid(),
                    Goals = request.Goals,
                    Assists = request.Assists,
                    YellowCards = request.YellowCards,
                    RedCards = request.RedCards,
                };

                _statisticRepository.Add(statistic);
                await _unitOfWork.Complete(cancellationToken);

                return Unit.Value;
            }
        }
    }

}
