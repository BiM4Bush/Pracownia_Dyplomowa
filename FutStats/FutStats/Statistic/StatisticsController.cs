using FutStats.Api.Abstractions;
using FutStats.Api.Statistic.InputModels;
using FutStats.Application.Messaging.Commands.Statistic;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutStats.Api.Statistic
{
    [Route("api/statistics")]
    public class StatisticsController : ApiBaseController
    {
        public StatisticsController(IMediator mediator) : base(mediator)
        {

        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddStatistic(CreateStatisticInputModel model)
        {
            await Mediator.Send(new CreateStatisticCommand(model.Goals, model.Assists, model.YellowCards, model.RedCards));
            return Ok();
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateStatistic(UpdateStatisticInputModel model)
        {
            await Mediator.Send(new UpdateStatisticCommand(model.StatisticId, model.Goals, model.Assists,
                model.YellowCards, model.RedCards));
            return Ok();
        }
    }
}
