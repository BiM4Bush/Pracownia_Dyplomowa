using FutStats.Domain.Enums;
using FutStats.Infrastructure.Database;
using FutStats.Infrastructure.Messaging.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static FutStats.Infrastructure.Messaging.Queries.GetAllPlayersQuery;

namespace FutStats.Infrastructure.Messaging.Queries
{
    public class GetAllPlayersQuery : IQuery<IReadOnlyCollection<PlayersResult>>
    {
        public class PlayersResult
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public int KitNumber { get; set; }
            public Positions Position { get; set; }
        }

        public class Handler : IQueryHandler<GetAllPlayersQuery, IReadOnlyCollection<PlayersResult>>
        {
            private readonly FutStatDbContext _dbContext;

            public Handler(FutStatDbContext dbContext)
            {
                _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            }

            public async Task<IReadOnlyCollection<PlayersResult>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
            {
                return await _dbContext.Player.Select(p => new PlayersResult
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    KitNumber = p.KitNumber,
                    Position = p.Position
                }).ToListAsync(cancellationToken);
            }
        }
    }
}
