using FutStats.Api.Abstractions;
using FutStats.Api.Player.InputModels;
using FutStats.Api.Player.ResultModels;
using FutStats.Application.Messaging.Commands.Player;
using FutStats.Infrastructure.Messaging.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FutStats.Infrastructure.Messaging.Queries.Player;

namespace FutStats.Api.Player
{
    [Route("api/players")]
    public class PlayersController : ApiBaseController
    {
        public PlayersController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        [ProducesResponseType(typeof(PlayersResultModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPlayers()
        {
            var response = await Mediator.Send(new GetAllPlayersQuery());

            var result = response.Select(p => new PlayersResultModel
            {
                Name = p.Name,
                Surname = p.Surname,
                KitNumber = p.KitNumber,
                Position = p.Position
            });

            return Ok(result);
        }

        [HttpGet("with-statistics")]
        [ProducesResponseType(typeof(PlayerWithStatisticResultModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPlayer([FromQuery] Guid PlayerId)
        {
            var response = await Mediator.Send(new GetPlayerWithStatisticsQuery(PlayerId));
            var result = new PlayerWithStatisticResultModel
            {
                Name = response.Name,
                Surname = response.Surname,
                Goals = response.Goals,
                Assists = response.Assists,
                YellowCards = response.YellowCards,
                RedCards = response.RedCards
            };
            return Ok(result);
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddPlayer(CreatePlayerInputModel model)
        {
            await Mediator.Send(new CreatePlayerCommand(model.Name, model.Surname, model.KitNumber, model.Position));
            return Ok();
        }

        [HttpPut("assign-statistic")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AssignStatistic(UpdatePlayerOfStatisticValueInputModel model)
        {
            await Mediator.Send(new UpdatePlayerOfStatisticCommand(model.StatisticId, model.PlayerId));
            return Ok();
        }
    }
}
