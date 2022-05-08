using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutStats.Api.Abstractions
{
    [ApiController]
    public abstract class ApiBaseController : ControllerBase
    {
        protected readonly IMediator Mediator;

        protected ApiBaseController(IMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
    }
}
