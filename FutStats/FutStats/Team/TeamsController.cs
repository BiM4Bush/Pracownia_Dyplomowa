using System;
using System.Linq;
using System.Threading.Tasks;
using FutStats.Api.Abstractions;
using FutStats.Api.Team.InputModels;
using FutStats.Api.Team.ResultModels;
using FutStats.Application.Messaging.Commands.Team;
using FutStats.Infrastructure.Messaging.Queries.Team;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FutStats.Api.Team
{
    [Route("api/teams")]
    public class TeamsController : ApiBaseController
    {
        public TeamsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("team")]
        [ProducesResponseType(typeof(TeamResultModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTeam([FromQuery] Guid TeamId)
        {
            var response = await Mediator.Send(new GetTeamQuery(TeamId));

            var result = new TeamResultModel
            {
                TeamName = response.TeamName,
                CoachName = response.CoachName,
                CoachSurname = response.CoachSurname,
                Players = response.Players.Select(p => new TeamResultModel.Player
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    KitNumber = p.KitNumber,
                    Position = p.Position
                }).ToList(),
                Week = response.Week
            };
            return Ok(result);
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddTeam(CreateTeamInputModel model)
        {
            await Mediator.Send(new CreateTeamCommand(model.Name, model.Week));
            return Ok();
        }

        [HttpPut("hire-coach")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> HireCoach(UpdateOfCoachInputModel model)
        {
            await Mediator.Send(new HireCoachCommand(model.TeamId, model.CoachId, model.CoachName, model.CoachSurname));
            return Ok();
        }

        [HttpPut("fire-coach")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FireCoach(UpdateOfCoachInputModel model)
        {
            await Mediator.Send(new FireCoachCommand(model.TeamId, model.CoachId, model.CoachName, model.CoachSurname));
            return Ok();
        }

        [HttpPut("sign-player")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignPlayer(UpdateOfPlayerInputModel model)
        {
            await Mediator.Send(new SignPlayerCommand(model.TeamId, model.PlayerId, model.PlayerName,
                model.PlayerSurname));
            return Ok();
        }


    }
}
