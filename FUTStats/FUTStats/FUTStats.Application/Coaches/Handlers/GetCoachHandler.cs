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
    public class GetCoachHandler: IRequestHandler<GetCoachQuery, QueryResult<CoachEntity>>
    {
        private readonly ICoachRepository _coachRepository;
        public GetCoachHandler(ICoachRepository coachRepository)
        {
            this._coachRepository = coachRepository;
        }

        public async Task<QueryResult<CoachEntity>> Handle(GetCoachQuery request, CancellationToken cancellationToken)
        {
            var result = await _coachRepository.GetCoachAsync(request.Id);
            return new QueryResult<CoachEntity>(true, result, "Successfully got coach");
        }
    }
}
