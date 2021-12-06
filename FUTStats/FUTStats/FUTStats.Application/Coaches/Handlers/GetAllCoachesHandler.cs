using FUTStats.Application.Coaches.Queries;
using FUTStats.Infrastructure.Interfaces;
using FUTStats.Infrastructure.Persistance.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FUTStats.Application.Coaches.Handlers
{
    public class GetAllCoachesHandler: IRequestHandler<GetAllCoachesQuery, QueryResult<IReadOnlyList<CoachEntity>>>
    {
        private readonly ICoachRepository _coachRepository;
        public GetAllCoachesHandler(ICoachRepository coachRepository)
        {
            this._coachRepository = coachRepository;
        }

        public async Task<QueryResult<IReadOnlyList<CoachEntity>>> Handle(GetAllCoachesQuery request, CancellationToken cancellationToken)
        {
            var result = await _coachRepository.GetAllCoaches();
            return new QueryResult<IReadOnlyList<CoachEntity>>(true, result, "Succesfully got all coaches");
        }
    }
}
