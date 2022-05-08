using FutStats.Infrastructure.Database;
using FutStats.Infrastructure.Messaging.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FutStats.Infrastructure.Messaging.Queries.Player
{
    public class GetPlayerWithStatisticsQuery : IQuery<GetPlayerWithStatisticsQuery.PlayerWithStatisticsResult>
    {
        public class PlayerWithStatisticsResult
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public int Goals { get; set; }
            public int Assists { get; set; }
            public int YellowCards { get; set; }
            public int RedCards { get; set; }
        }

        public Guid PlayerId { get; }

        public GetPlayerWithStatisticsQuery(Guid playerId)
        {
            PlayerId = playerId;
        }
    }

    public class Handler : IQueryHandler<GetPlayerWithStatisticsQuery, GetPlayerWithStatisticsQuery.PlayerWithStatisticsResult>
    {
        private readonly FutStatDbContext _dbContext;

        public Handler(FutStatDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<GetPlayerWithStatisticsQuery.PlayerWithStatisticsResult> Handle(GetPlayerWithStatisticsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Player
                .Where(p => p.Id == request.PlayerId)
                .Select(p => new GetPlayerWithStatisticsQuery.PlayerWithStatisticsResult
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    Goals = p.StatisticEntity.Goals,
                    Assists = p.StatisticEntity.Assists,
                    YellowCards = p.StatisticEntity.YellowCards,
                    RedCards = p.StatisticEntity.RedCards
                }).SingleOrDefaultAsync(cancellationToken);
        }
    }
}
