using FUTStats.Application.Statistics.Commands;
using FUTStats.Application.Statistics.Queries;
using FUTStats.Infrastructure.Persistance.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FUTStats.API.Controllers
{
    [Route("api/statistics")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IReadOnlyList<StatisticEntity>> GetAllStatistics()
        {
            var query = new GetAllStatisticsQuery();
            var result = await _mediator.Send(query);
            return result.Result;
        }

        [HttpGet("{id}")]
        public async Task<StatisticEntity> GetStatistic(Guid Id)
        {
            var query = new GetStatisticQuery(Id);
            var result = await _mediator.Send(query);
            return result.Result;
        }

        [HttpPost]
        public async Task<ActionResult> PostStatistic([FromBody] StatisticEntity statisticEntity)
        {
            var command = new CreateStatisticCommand(statisticEntity);
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result.Result) : Problem(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutStatistic(Guid id, [FromBody] StatisticEntity statisticEntity)
        {
            var command = new UpdateStatisticCommand(id, statisticEntity);
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result.Result) : Problem(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStatistic(Guid id)
        {
            var command = new DeleteStatisticCommand(id);
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result.Result) : Problem(result.Message);
        }
    }
}
