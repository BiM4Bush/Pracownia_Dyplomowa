using FUTStats.Application.Coaches.Commands;
using FUTStats.Application.Coaches.Queries;
using FUTStats.Infrastructure.Persistance.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FUTStats.API.Controllers
{
    [Route("api/coaches")]
    [ApiController]
    public class CoachesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CoachesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IReadOnlyList<CoachEntity>> GetAllCoaches()
        {
            var query = new GetAllCoachesQuery();
            var result = await _mediator.Send(query);
            return result.Result;
        }

        [HttpGet("{id}")]
        public async Task<CoachEntity> GetCoach(Guid Id)
        {
            var query = new GetCoachQuery(Id);
            var result = await _mediator.Send(query);
            return result.Result;
        }

        [HttpPost]
        public async Task<ActionResult> PostCoach([FromBody] CoachEntity playerEntity)
        {
            var command = new CreateCoachCommand(playerEntity);
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result.Result) : Problem(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutCoach(Guid id, [FromBody] CoachEntity playerEntity)
        {
            var command = new UpdateCoachCommand(id, playerEntity);
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result.Result) : Problem(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCoach(Guid id)
        {
            var command = new DeleteCoachCommand(id);
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result.Result) : Problem(result.Message);
        }
    }
}
