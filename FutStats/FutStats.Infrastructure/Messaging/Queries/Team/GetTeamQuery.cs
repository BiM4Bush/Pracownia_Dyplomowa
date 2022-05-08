using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FutStats.Domain.Enums;
using FutStats.Infrastructure.Database;
using FutStats.Infrastructure.Messaging.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace FutStats.Infrastructure.Messaging.Queries.Team
{
    public class GetTeamQuery : IQuery<GetTeamQuery.TeamResult>
    {
        public class TeamResult
        {
            public string TeamName { get; set; }
            public List<Player> Players { get; set; }
            public string CoachName { get; set; }
            public string CoachSurname { get; set; }
            public int Week { get; set; }
            public class Player
            {
                public string Name { get; set; }
                public string Surname { get; set; }
                public int KitNumber { get; set; }
                public Positions Position { get; set; }
            }
        }

        public Guid TeamId { get; }

        public GetTeamQuery(Guid teamId)
        {
            TeamId = teamId;
        }

        public class Handler : IQueryHandler<GetTeamQuery, TeamResult>
        {
            private readonly FutStatDbContext _dbContext;

            public Handler(FutStatDbContext dbContext)
            {
                _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            }

            public async Task<TeamResult> Handle(GetTeamQuery request, CancellationToken cancellationToken)
            {
                var players = await _dbContext.Player
                    .Where(p => p.TeamId == request.TeamId)
                    .Select(p => new TeamResult.Player
                    {
                        Name = p.Name,
                        Surname = p.Surname,
                        KitNumber = p.KitNumber,
                        Position = p.Position
                    }).ToListAsync(cancellationToken);

                return await _dbContext.Team
                    .Where(p => p.Id == request.TeamId)
                    .Select(p => new TeamResult
                    {
                        TeamName = p.Name,
                        CoachName = p.Coach.Name,
                        CoachSurname = p.Coach.Surname,
                        Players = players,
                        Week = p.Week
                    }).SingleOrDefaultAsync(cancellationToken);
            }
        }
    }
}
