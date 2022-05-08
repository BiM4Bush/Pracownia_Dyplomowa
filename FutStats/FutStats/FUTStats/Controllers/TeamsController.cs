using FUTStats.Application.Teams.Commands;
using FUTStats.Application.Teams.Queries;
using FUTStats.Infrastructure.Persistance.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FUTStats.API.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamsController : Controller
    {
        private readonly IMediator _mediator;
        public TeamsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IReadOnlyList<TeamEntity>> GetAllTeams()
        {
            var query = new GetAllTeamsQuery();
            var result = await _mediator.Send(query);
            return result.Result;
        }

        [HttpGet("{id}")]
        public async Task<TeamEntity> GetTeam(Guid Id)
        {
            var query = new GetTeamQuery(Id);
            var result = await _mediator.Send(query);
            return result.Result;
        }

        [HttpPost]
        public async Task<ActionResult> PostTeam([FromBody] TeamEntity teamEntity)
        {
            var command = new CreateTeamCommand(teamEntity);
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result.Result) : Problem(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutTeam(Guid id, [FromBody] TeamEntity teamEntity)
        {
            var command = new UpdateTeamCommand(id, teamEntity);
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result.Result) : Problem(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeam(Guid id)
        {
            var command = new DeleteTeamCommand(id);
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result.Result) : Problem(result.Message);
        }
    }
}
