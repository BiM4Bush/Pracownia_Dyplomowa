using FutStats.Api.Abstractions;
using FutStats.Api.Coach.ResultModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FutStats.Infrastructure.Messaging.Queries.Coach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FutStats.Api.Coach.InputModels;
using FutStats.Application.Messaging.Commands;

namespace FutStats.Api.Coach
{
    [Route("api/coaches")]
    public class CoachesController : ApiBaseController
    {
        public CoachesController(IMediator mediator) : base(mediator)
        {
            
        }

        [HttpGet]
        [ProducesResponseType(typeof(CoachesResultModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllCoaches()
        {
            var response = await Mediator.Send(new GetAllCoachesQuery());

            var result = response.Select(p => new CoachesResultModel
            {
                Name = p.Name,
                Surname = p.Surname,
                Nationality = p.Nationality
            }).ToList();

            return Ok(result);

        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddCoach(CreateCoachInputModel model)
        {
            await Mediator.Send(new CreateCoachCommand(model.Name, model.Surname, model.Nationality));
            return Ok();
        }
        
    }
}
