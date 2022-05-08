using FutStats.Domain.Entities;
using FutStats.Domain.Enums;
using FutStats.Domain.Repositories.Entities;
using FutStats.Infrastructure.Database;
using FutStats.Infrastructure.Messaging.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static FutStats.Infrastructure.Messaging.Queries.Coach.GetAllCoachesQuery;

namespace FutStats.Infrastructure.Messaging.Queries.Coach
{
    public class GetAllCoachesQuery : IQuery<IReadOnlyCollection<CoachesResult>>
    {
        public class CoachesResult
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public Nationalities Nationality { get; set; }
        }

        public class Handler : IQueryHandler<GetAllCoachesQuery, IReadOnlyCollection<CoachesResult>>
        {
            private readonly FutStatDbContext _dbContext;

            public Handler(FutStatDbContext dbContext)
            {
                _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            }
            public async Task<IReadOnlyCollection<CoachesResult>> Handle(GetAllCoachesQuery request, CancellationToken cancellationToken)
            {
                return await _dbContext.Coach.Select(p => new CoachesResult
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    Nationality = p.Nationality
                }).ToListAsync(cancellationToken);
            }
        }
    }
}
