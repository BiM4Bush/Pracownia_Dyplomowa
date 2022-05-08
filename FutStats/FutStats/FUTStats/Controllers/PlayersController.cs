using FUTStats.Application.Players.Commands;
using FUTStats.Application.Players.Queries;
using FUTStats.Infrastructure.Persistance.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FUTStats.API.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlayersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IReadOnlyList<PlayerEntity>> GetAllPLayers()
        {
            var query = new GetAllPlayersQuery();
            var result = await _mediator.Send(query);
            return result.Result;
        }

        [HttpGet("{id}")]
        public async Task<PlayerEntity> GetPlayer(Guid Id)
        {
            var query = new GetPlayerQuery(Id);
            var result = await _mediator.Send(query);
            return result.Result;
        }
        
        [HttpPost]
        public async Task<ActionResult> PostPlater([FromBody] PlayerEntity playerEntity)
        {
            var command = new CreatePlayerCommand(playerEntity);
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result.Result) : Problem(result.Message);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> PutPlayer(Guid id, [FromBody] PlayerEntity playerEntity)
        {
            var command = new UpdatePlayerCommand(id, playerEntity);
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result.Result) : Problem(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlayer(Guid id)
        {
            var command = new DeletePlayerCommand(id);
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result.Result) : Problem(result.Message);
        }
    }
}
